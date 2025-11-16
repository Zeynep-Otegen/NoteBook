using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace NoteBook
{
    public partial class Form1 : Form
    {
        private BindingList<Note> notes = new BindingList<Note>();
        private int currentNoteIndex = -1;
        private readonly string notesFilePath = Path.Combine(Application.StartupPath, "notes.xml");
        private bool isNewNote = true;

        public Form1()
        {
            InitializeComponent();
        }

        public class Note
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public DateTime CreatedDate { get; set; }

            public override string ToString()
            {
                return $"{Title} - {CreatedDate:dd.MM.yyyy HH:mm}";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Not Defteri Uygulaması";

            // ListBox'ı veri kaynağı ile bağla
            lstNot.DataSource = notes;

            // Notları yükle
            LoadNotes();

            // Kontrolleri temizle
            ClearForm();

            UpdateStatus("Uygulama hazır");
        }

        private void ClearForm()
        {
            txtBaslik.Clear();
            txtNote.Clear();
            currentNoteIndex = -1;
            isNewNote = true;
            lstNot.ClearSelected();
            btnSil.Enabled = false;
        }

        private void UpdateNotesList()
        {
            // BindingList otomatik güncellenir, manuel güncellemeye gerek yok
            // Sadece seçimi güncelle - GÜVENLİ VERSİYON
            if (currentNoteIndex >= 0 && currentNoteIndex < notes.Count && lstNot.Items.Count > currentNoteIndex)
            {
                try
                {
                    lstNot.SelectedIndex = currentNoteIndex;
                }
                catch (ArgumentOutOfRangeException)
                {
                    // Eğer index geçersizse, son geçerli index'i seç veya seçimi temizle
                    if (lstNot.Items.Count > 0)
                    {
                        lstNot.SelectedIndex = lstNot.Items.Count - 1;
                        currentNoteIndex = lstNot.SelectedIndex;
                    }
                    else
                    {
                        lstNot.ClearSelected();
                        currentNoteIndex = -1;
                    }
                }
            }
            else if (notes.Count == 0)
            {
                lstNot.ClearSelected();
                currentNoteIndex = -1;
            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            // Mevcut not kaydedilmemişse kaydetmek isteyip istemediğini sor
            if (!IsFormEmpty() && isNewNote)
            {
                DialogResult result = MessageBox.Show(
                    "Mevcut not kaydedilsin mi?",
                    "Kaydet",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SaveCurrentNote();
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            ClearForm();
            txtBaslik.Focus();
            UpdateStatus("Yeni not oluşturuldu");
        }

        private bool IsFormEmpty()
        {
            return string.IsNullOrWhiteSpace(txtBaslik.Text) &&
                   string.IsNullOrWhiteSpace(txtNote.Text);
        }

        private void SaveCurrentNote()
        {
            if (string.IsNullOrWhiteSpace(txtBaslik.Text))
            {
                MessageBox.Show("Lütfen bir başlık girin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBaslik.Focus();
                return;
            }

            if (isNewNote)
            {
                // Yeni not oluştur
                Note newNote = new Note
                {
                    Title = txtBaslik.Text.Trim(),
                    Content = txtNote.Text,
                    CreatedDate = DateTime.Now
                };

                notes.Add(newNote);
                currentNoteIndex = notes.Count - 1;
                isNewNote = false;
                UpdateStatus("Yeni not kaydedildi");
            }
            else if (currentNoteIndex >= 0 && currentNoteIndex < notes.Count)
            {
                // Mevcut notu güncelle
                notes[currentNoteIndex].Title = txtBaslik.Text.Trim();
                notes[currentNoteIndex].Content = txtNote.Text;
                UpdateStatus("Not güncellendi");
            }

            SaveNotes();
            UpdateNotesList(); // Bu metod zaten seçim işlemini yapıyor
            UpdateDeleteButtonState();
        }



        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SaveCurrentNote();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lstNot.SelectedIndex < 0 || currentNoteIndex < 0)
            {
                MessageBox.Show("Lütfen silmek için bir not seçin.", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var noteToDelete = notes[currentNoteIndex];
            var result = MessageBox.Show(
                $"\"{noteToDelete.Title}\" başlıklı not silinsin mi?",
                "Not Sil",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                notes.RemoveAt(currentNoteIndex);
                SaveNotes();
                ClearForm();
                UpdateStatus("Not silindi");

                // Listenin son öğesi silindiyse, bir öncekini seç
                if (notes.Count > 0)
                {
                    if (currentNoteIndex >= notes.Count)
                    {
                        currentNoteIndex = notes.Count - 1;
                    }
                    if (currentNoteIndex >= 0 && lstNot.Items.Count > currentNoteIndex)
                    {
                        lstNot.SelectedIndex = currentNoteIndex;
                    }
                }
            }
        }

        private void lstNot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstNot.SelectedIndex >= 0 && lstNot.SelectedIndex < notes.Count)
            {
                currentNoteIndex = lstNot.SelectedIndex;
                Note selectedNote = notes[currentNoteIndex];

                txtBaslik.Text = selectedNote.Title;
                txtNote.Text = selectedNote.Content;
                isNewNote = false;

                UpdateDeleteButtonState();
                UpdateStatus($"Not yüklendi: {selectedNote.Title}");
            }
            else if (lstNot.SelectedIndex == -1 && notes.Count > 0)
            {
                // Seçim kaldırıldıysa ama notlar varsa
                UpdateDeleteButtonState();
            }
        }

        private void UpdateDeleteButtonState()
        {
            // ListBox'ta seçili öğe varsa veya geçerli bir not index'i varsa sil butonunu aktif et
            btnSil.Enabled = (lstNot.SelectedIndex >= 0) ||
                             (currentNoteIndex >= 0 && currentNoteIndex < notes.Count);
        }

        private void UpdateStatus(string message)
        {
            // StatusStrip varsa:
            // toolStripStatusLabel1.Text = message;

            // Veya form başlığına ekle:
            this.Text = $"Not Defteri - {message}";
        }

        private void SaveNotes()
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<Note>));
                using (var stream = File.Create(notesFilePath))
                {
                    serializer.Serialize(stream, notes.ToList());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Notlar kaydedilemedi: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadNotes()
        {
            try
            {
                if (!File.Exists(notesFilePath))
                    return;

                var serializer = new XmlSerializer(typeof(List<Note>));
                using (var stream = File.OpenRead(notesFilePath))
                {
                    var loadedNotes = (List<Note>)serializer.Deserialize(stream);
                    if (loadedNotes != null)
                    {
                        notes = new BindingList<Note>(loadedNotes);

                        // DATA SOURCE'U YENİDEN ATA - BUNU EKLE
                        lstNot.DataSource = notes;
                    }
                }
                UpdateStatus($"{notes.Count} not yüklendi");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Notlar yüklenemedi: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                notes = new BindingList<Note>();
                // BU DURUMDA DA DATA SOURCE'U GÜNCELLE
                lstNot.DataSource = notes;
            }
            }

        // TextBox değişikliklerinde isNewNote durumunu güncelle
        private void txtBaslik_TextChanged(object sender, EventArgs e)
        {
            if (lstNot.SelectedIndex < 0)
            {
                isNewNote = true;
            }
        }

        private void txtNote_TextChanged(object sender, EventArgs e)
        {
            if (lstNot.SelectedIndex < 0)
            {
                isNewNote = true;
            }
        }
    }
}
