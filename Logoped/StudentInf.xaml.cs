using System.Windows;
using System.Windows.Controls;
using System.IO;
using Microsoft.Win32;
using Microsoft.Office.Interop.Word;
using System;
using System.Windows.Xps.Packaging;
using System.Windows.Documents;
using System.Xml.Linq;
using Page = System.Windows.Controls.Page;

namespace Logoped
{
    /// <summary>
    /// Логика взаимодействия для StudentInf.xaml
    /// </summary>
    public partial class StudentInf : Page
    {
        public StudentInf()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.framsus.GoBack();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".doc";
            dlg.Filter = "Word documents (.doc)|*.*";

            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                if (dlg.FileName.Length > 0)
                {
                    SelectedFileTextBox.Text = dlg.FileName;
                    string newXPSDocumentName = String.Concat(System.IO.Path.GetDirectoryName(dlg.FileName), "\\",
                                   System.IO.Path.GetFileNameWithoutExtension(dlg.FileName), ".xps");

                    documentViewer1.Document =
                        ConvertWordDocToXPSDoc(dlg.FileName, newXPSDocumentName).GetFixedDocumentSequence();
                }
            }
        }

        private XpsDocument ConvertWordDocToXPSDoc(string wordDocName, string xpsDocName)
        {
            Microsoft.Office.Interop.Word.Application
                wordApplication = new Microsoft.Office.Interop.Word.Application();
            wordApplication.Documents.Add(wordDocName);

            Document doc = wordApplication.ActiveDocument;
            try
            {
                doc.SaveAs(xpsDocName, WdSaveFormat.wdFormatXPS);
                wordApplication.Quit();

                XpsDocument xpsDoc = new XpsDocument(xpsDocName, System.IO.FileAccess.Read);
                return xpsDoc;
            }
            catch (Exception exp)
            {
                string str = exp.Message;
            }
            return null;
        }
    }
}
