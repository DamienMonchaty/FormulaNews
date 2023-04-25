using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using SQLite;
using System.IO;
using FOne_MobileApp.Models;
using System.Linq;
using System.Globalization;
using Environment = System.Environment;

namespace FOne_MobileApp.Droid
{
    //[Activity(Label = "FormulaNews", Icon = "@drawable/logoicon" )]
    [Activity(Label = "FormulaNews", Icon = "@drawable/logoicon", Theme = "@style/splashscreen", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize, LaunchMode = LaunchMode.SingleTop)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        SQLiteConnection dataBase;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.CreateDatabase();
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void CreateDatabase()
        {
            dataBase = this.GetConnection();
            dataBase.CreateTable<Blog>();

            dataBase.Query<Blog>("DELETE From Blog");

            var textVM = "Max Verstappen est un pilote de course néerlandais de 24 ans qui court" +
                " actuellement pour l écurie de Formule 1 Red Bull Racing. Il est considéré comme l un des pilotes" +
                " les plus talentueux et les plus prometteurs de sa génération et est déjà un habitué des podiums.";

            var textVM2 = "En 2015, Verstappen a été promu chez Toro Rosso, l équipe jumelle de Red Bull Racing, et " +
                "est devenu le plus jeune pilote de l histoire de la Formule 1 à seulement 17 ans. Il a immédiatement " +
                "fait preuve d un talent remarquable, remportant plusieurs points en championnat dès sa première saison.";

            var textVM3 = "Verstappen est connu pour son style de conduite agressif et déterminé, avec une capacité" +
                " incroyable à maintenir sa vitesse et sa concentration sur la piste. Il est aussi un pilote passionné " +
                "et engagé, travaillant en étroite collaboration avec son équipe pour optimiser chaque aspect de sa performance.";

            var textSV = "Sebastian Vettel, quadruple champion du monde de Formule 1, a signé un contrat pour revenir dans " +
                "la discipline avec l équipe Aston Martin F1 (anciennement Racing Point) pour la saison 2021. " +
                "Vettel avait quitté l équipe Ferrari à la fin de la saison précédente.";

            var textSV2= "La saison 2021, la première pour Vettel avec son nouvel employeur, a commencé difficilement. " +
                "Le pilote allemand a connu des problèmes de performance et de fiabilité, ainsi qu une certaine " +
                "part de malchance, tandis que son coéquipier Lance Stroll remportait un podium dès la deuxième course de la saison.";

            var textSV3= "Cependant, Vettel a retrouvé sa forme au cours de la saison, marquant des points " +
                "régulièrement et obtenant son premier podium avec Aston Martin lors du Grand Prix d Azerbaïdjan. " +
                "Il a également fait preuve d un leadership et d une expérience précieux pour aider son équipe à améliorer " +
                "ses performances tout au long de la saison. Le retour de Vettel en Formule 1 a été accueilli avec enthousiasme " +
                "par les fans de la discipline, qui avaient hâte de voir le pilote expérimenté de retour sur la grille de départ. " +
                "Sa présence ajoute une touche de classe et d expérience à une discipline qui voit souvent une rotation rapide des pilotes.";

            var textHM = "Helmut Marko est un ancien pilote de course professionnel autrichien " +
                "né le 27 avril 1943, connu pour être aujourd hui conseiller aux écuries " +
                "Red Bull en Formule 1 et responsable du programme de développement des pilotes de Red Bull.";

            var textHM2 = "Il est également impliqué dans les décisions de gestion de l équipe et a joué un rôle clé " +
                "dans la promotion de jeunes pilotes talentueux comme Sebastian Vettel et Max Verstappen. Marko a une " +
                "longue histoire dans le sport automobile, ayant remporté plusieurs courses de voitures de tourisme et " +
                "de monoplaces tout au long de sa carrière de pilote de course professionnelle, y compris avec des victoires " +
                "en Formule One, en Formule 2 et lors des 24 heures du Mans en 1971.";

            var textHM3 = "Il est souvent décrit comme une figure controversée dans le sport en raison de son franc-parler " +
                "et de ses décisions controversées.";

            //Insert data in to table 
            dataBase.Query<Blog>("INSERT INTO Blog (Title,SubTitle,Text1,Text2,Text3,AuthorName,DateCreated,Image)values ('Max Verstappen Champion','Champion 3 etoiles ?','" + textVM + "','" + textVM2 + "','" + textVM3 + "','Jonh Wick','" + new DateTime(2023, 3, 3).ToString(CultureInfo.GetCultureInfo("FR-fr")) + "','Max.png')");
            dataBase.Query<Blog>("INSERT INTO Blog (Title,SubTitle,Text1,Text2,Text3,AuthorName,DateCreated,Image)values ('Le retour de Sebastian Vettel','On t attend !','" + textSV + "','" + textSV2 + "','" + textSV3 + "','Jonh Wick','" + new DateTime(2023, 3, 3).ToString(CultureInfo.GetCultureInfo("FR-fr")) + "','AstonMartin.png')");
            dataBase.Query<Blog>("INSERT INTO Blog (Title,SubTitle,Text1,Text2,Text3,AuthorName,DateCreated,Image)values ('Qui est Helmut Marko ?','La terreur des paddocks','" + textHM + "','" + textHM2 + "','" + textHM3 + "','Jonh Wick','" + new DateTime(2023, 3, 3).ToString(CultureInfo.GetCultureInfo("FR-fr")) + "','redbullf1.jpg')");

        }


        public SQLiteConnection GetConnection()
        {
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentPath, "MySQLite.db");

            // This is where we copy in the prepopulated database
            Console.WriteLine(path);

            var conn = new SQLite.SQLiteConnection(path);

            // Return the database connection 
            return conn;
        }

        void ReadWriteStream(Stream readStream, Stream writeStream)
        {
            int Length = 256;
            Byte[] buffer = new Byte[Length];
            int bytesRead = readStream.Read(buffer, 0, Length);
            // write the required bytes
            while (bytesRead > 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = readStream.Read(buffer, 0, Length);
            }
            readStream.Close();
            writeStream.Close();
        }
    }
}