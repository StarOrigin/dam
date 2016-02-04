using LiteDB;
using org.starorigin.dam.core.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace org.starorigin.dam.core.db
{
    public class DbUtils
    {
        private static LiteDatabase db;
        public static LiteDatabase Db
        {
            get
            {
                if (db == null) db = new LiteDatabase(@".\dam.db");
                return db;
            }
        }
        public static void InitDb()
        {
            if (Db.CollectionExists("Server"))
                Db.DropCollection("Server");
            var servers = Db.GetCollection<Server>("Server");
            var local = new Server() { Name = "本地", BuiltIn = true };
            servers.Insert(local);

            if (Db.CollectionExists("Catalog"))
                Db.DropCollection("Catalog");
            var catalogs = Db.GetCollection<Catalog>("Catalog");
            var images = new Catalog() { Name = "图像", BuiltIn = true, Parent = null };
            var albums = new Catalog() { Name = "相册", BuiltIn = true, Parent = images };
            catalogs.Insert(images);
            catalogs.Insert(albums);
        }
    }
}
