using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JewelryStore.Models;
using System.Drawing;
using System.IO;


namespace JewelryStore.Data
{
    public class DBInitializer
    {

        public static void Initialize(JewelryContext context)
        {
            context.Database.EnsureCreated();

           
            //if (context.Provisioners.Any())
            //    {
            //        return;   // DB has been seeded
            //    }
            //var provisioners = new Provisioner[]
            //{
            //    new Provisioner{ Name = "Чудінова", TelNumber="+380632026929" },
            //    new Provisioner { Name = "Прокопчук", TelNumber = "+380971318498" },
            //    new Provisioner { Name = "Томащук", TelNumber = "+380664706665" },
            //    new Provisioner { Name = "Владимирець", TelNumber = "+380958332641" }

            //};
            //foreach (Provisioner p in provisioners)
            //{
            //    context.Provisioners.Add(p);
            //}
            //context.SaveChanges();

            //var oComponents = new OComponent[]
            //{
            //    new OComponent {Name="конюшина біла", pID= 2,Cost="", InStock=false },
            //    new OComponent {Name="конюшина рожева", pID= 2,Cost="", InStock=true },
            //    new OComponent {Name="алісіум білий", pID= 2,Cost="", InStock=false },
            //    new OComponent {Name="кермек", pID= 2,Cost="", InStock=false },
            //    new OComponent {Name="лист звичайний", pID= 2,Cost="", InStock=false },
            //    new OComponent {Name="лист чорниці", pID= 2,Cost="", InStock=false },
            //    new OComponent {Name="лист хвої", pID= 2,Cost="", InStock=false },
            //    new OComponent {Name="мати-й-мачуха", pID= 2,Cost="", InStock=false },
            //    new OComponent {Name="деревій", pID= 2,Cost="", InStock=false },


            //};
            //foreach (OComponent oc in oComponents)
            //{
            //    context.OComponents.Add(oc);
            //}
            //context.SaveChanges();

            //var eResin = new EResin[]
            //{
            //    new EResin {Name="MagicCrystal",  pID= 3, Cost="100/100ml", InStock=true },
            //   // new EResin {Name="GedeoPebeo",  pID= 3, Cost="150/100ml", InStock=true }


            //};
            //foreach (EResin er in eResin)
            //{
            //    context.EResins.Add(er);
            //}
            //context.SaveChanges();
            //var metals = new Metals[]
            //{
            //    new Metals{Name ="золото"},
            //    new Metals{Name ="срібло"},
            //    new Metals{Name ="мідь"},
            //    new Metals{Name ="рожеве золото"},
            //    new Metals{Name ="бронза"},

            //};
            //foreach (Metals m in metals)
            //{
            //    context.Metals.Add(m);
            //}
            //context.SaveChanges();

            //var jTypes = new JType[]
            //{
            //    new JType {Name="кулон звичайний"},
            //    new JType {Name="кулон геометричний"},
            //    new JType {Name="сережки"},
            //    new JType {Name="каблучка"}
            //};
            //foreach (JType jt in jTypes)
            //{
            //    context.jTypes.Add(jt);
            //}
            //context.SaveChanges();

            //var mComponents = new MComponent[]
            //    {
            //    new MComponent {Name="cрібний кулон", mID =1, jtID=1, pID=4, InStock=true, Cost=""},
            //    new MComponent {Name="срібний геометричний кулон", mID =1, jtID=2, pID=4, InStock=true, Cost=""},
            //    new MComponent {Name="срібні сережки", mID =1, jtID=3, pID=4, InStock=true, Cost=""},
            //    new MComponent {Name="срібна каблучка", mID =1, jtID=4, pID=4, InStock=true, Cost=""},
            //    new MComponent {Name="золотий кулон", mID =2, jtID=1, pID=4, InStock=true, Cost=""},
            //    new MComponent {Name="золотий геометричний кулон", mID =2, jtID=2, pID=4, InStock=true, Cost=""},
            //    new MComponent {Name="золоті сережки", mID =2, jtID=3, pID=4, InStock=true, Cost=""},
            //    new MComponent {Name="золота каблучка", mID =2, jtID=4, pID=4, InStock=true, Cost=""},
            //    new MComponent {Name="мідний кулон", mID =3, jtID=1, pID=4, InStock=true, Cost=""},
            //    new MComponent {Name="мідний геометричний кулон", mID =3, jtID=2, pID=4, InStock=true, Cost=""},
            //    new MComponent {Name="мідні сережки", mID =3, jtID=3, pID=4, InStock=true, Cost=""},
            //    new MComponent {Name="мідна каблучка", mID =3, jtID=4, pID=4, InStock=true, Cost=""},
            //    new MComponent {Name="рожеві сережки", mID =4, jtID=3, pID=4, InStock=true, Cost=""},
            //    new MComponent {Name="рожева каблучка", mID =4, jtID=4, pID=4, InStock=true, Cost=""},
            //    };
            //foreach (MComponent mc in mComponents)
            //{
            //    context.MComponents.Add(mc);
            //}
            //context.SaveChanges();

            // System.Drawing.ImageConverter
            var jewelries = new Jewelry[]
             {
               //new Jewelry{Name="p1", Image= File.ReadAllBytes("~/C:/Users/Valentine/source/repos/JewelryStore/JewelryStore/wwwroot/img/p1.jpg"),mcID=9, erID=1,oID=3, Cost="200", InStock=true } 
                    //new byte[ wwroo (byte[])converter.ConvertTo("img/p1.jpg", typeof(byte[]))}
             };
            foreach (Jewelry j in jewelries)
            {
                context.Jewelries.Add(j);
            }
            context.SaveChanges();


        }
    }
}
