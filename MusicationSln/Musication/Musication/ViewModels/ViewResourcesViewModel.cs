using Musication;
using Musication.Services.Interfaces;
using Musication.ViewModels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Musication.ViewModels
{

}
    public class ViewResourcesViewModel : ViewModelBase
{
    private string _pdfPath;

    private IDocumentViewer _documentViewer;

    private DelegateCommand _openPdfCommand;
    public DelegateCommand OpenPdfCommand =>
        _openPdfCommand ?? (_openPdfCommand = new DelegateCommand(ExecuteOpenPdfCommand));

    public ViewResourcesViewModel(INavigationService navigationService, IDocumentViewer documentViewer) : base(navigationService)
    {
        _pdfPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        _documentViewer = documentViewer;


    }

    void ExecuteOpenPdfCommand()
    {
        CopyEmbeddedContent("Musication.pdffile.Resources.pdf", "Resources.pdf");

        _documentViewer.ViewDocument(_pdfPath,"Resources.pdf");
    }

    private void CopyEmbeddedContent(string resourceName, string outputFileName)
    {
        var assembly = typeof(App).GetTypeInfo().Assembly;

        using (Stream resFilestream = assembly.GetManifestResourceStream(resourceName))
        {
            if (resFilestream == null) return;
            byte[] ba = new byte[resFilestream.Length];
            resFilestream.Read(ba, 0, ba.Length);

            File.WriteAllBytes(Path.Combine(_pdfPath, outputFileName), ba);
        }
    }

}
