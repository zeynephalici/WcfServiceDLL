using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceDLL
{
    // NOT: "WcfService" sınıf adını kodda ve yapılandırma dosyasında birlikte değiştirmek için "Yeniden Düzenle" menüsündeki "Yeniden Adlandır" komutunu kullanabilirsiniz.
    public class WcfService : IWcfService


    {
        public int id { get; set; }
        public string adi { get; set; }

        DAL.Execute exec = new DAL.Execute();
        public string hataMesaji = "";
        
        
        public DataTable Listele()
        {

            DataTable dt = new DataTable();
            dt.TableName = "dt";
            dt = exec.executeDT("select * from Musteri", null, false, ref hataMesaji);

            return dt;

        }

        public bool Guncelle()
        {
            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@id", id));
            _params.Add(new SqlParameter("@adi", adi));

            bool sonuc = exec.execute("update Musteri set adi=@adi where id=@id", _params.ToArray(), false, ref hataMesaji);
            hataMesaji = (sonuc == true) ? "True" : "False";
            return sonuc;

        }

        public bool Sil()
        {
            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@id", id));

            

            bool sonuc= exec.execute("delete from Musteri where id=@id", _params.ToArray(), false, ref hataMesaji);
            hataMesaji = (sonuc == true) ? "True" : "False";
            return sonuc;
        }

        public bool Ekle()
        {
            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@adi", adi));

            bool sonuc= exec.execute("insert into Musteri (adi) values(@adi)", _params.ToArray(), false, ref hataMesaji);
            hataMesaji = (sonuc == true) ? "True" : "False";
            return sonuc;
        }

    }
}
