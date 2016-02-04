using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using org.starorigin.dam.core.model;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace org.starorigin.dam.launcher.ViewModels
{
    [POCOViewModel]
    [MetadataType(typeof(Metadata))]
    public class PhotoViewModel
    {
        public class Metadata : IMetadataProvider<PhotoViewModel>
        {
            void IMetadataProvider<PhotoViewModel>.BuildMetadata
                (MetadataBuilder<PhotoViewModel> builder)
            {
                //builder.Property(x => x.UserName).
                //    OnPropertyChangedCall(x => x.Update());
                //builder.Property(x => x.IsEnabled).
                //    DoNotMakeBindable();
            }
        }
    }
}