using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceDLL
{
    // NOT: "IWcfService" arabirim adını kodda ve yapılandırma dosyasında birlikte değiştirmek için "Yeniden Düzenle" menüsündeki "Yeniden Adlandır" komutunu kullanabilirsiniz.
    [ServiceContract]
    public interface IWcfService
    {
        [OperationContract]
        DataTable Listele();


        [OperationContract]
        bool Ekle();

        [OperationContract]
        bool Guncelle();

        [OperationContract]
        bool Sil();
    }
}
