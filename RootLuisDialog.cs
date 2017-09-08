namespace TRPlateBot
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Bot.Builder.Dialogs;
    using Microsoft.Bot.Builder.Luis;
    using Microsoft.Bot.Builder.Luis.Models;
    using Microsoft.Bot.Connector;
    using System.Collections.Generic;

    [LuisModel("961b24bb-113b-4f97-a434-b1f0b5f7256c", "3f80b9bd6d8b4bc693aa19c1bd202a22")]
    [Serializable]
    public class RootLuisDialog : LuisDialog<object>
    {      
        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Sorry, I did not understand '{result.Query}'. Type 'help' if you need assistance.";

            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }


        //which universities are in [ $CityName ] ?
        //show which universities in [ $CityName ]

        // show which departments at [ $UniversityName ] university
        // which departments are at [ $UniversityName ] university ?


        [LuisIntent("showHelp")]
        public async Task Help(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("You can ask 'which universities are in [ $CityName ] ?' or " +
                "'which departments are at [ $UniversityName ] university ?' ");

            context.Wait(this.MessageReceived);
        }

        const string HeroCard = "What about 57 ?";
        const string ThumbnailCard = "Thumbnail Card";

        private async Task OnOptionSelected(IDialogContext context, IAwaitable<string> result)
        {
            try
            {
                string optionSelected = await result;

            }
            catch (Exception ex)
            {

            }
        }

        [LuisIntent("showUniversitiesInTheCity")]
        public async Task teachLanguage(IDialogContext context, LuisResult result)
        {
            if (result.Entities.Count == 0)
            {
                await context.PostAsync("Hi there! I'm TRPlate Bot 🤖, please feel free to ask me any question 😊");
            }
            else
            {
                 foreach (var searchEntity in result.Entities)
                 {
                     if (searchEntity.Type == "CityName")
                     {
                         if (searchEntity.Entity == "İstanbul" || searchEntity.Entity == "istanbul")
                         {

                            /* await context.PostAsync("İstanbul Üniversitesi \n\n"
                                             + "İstanbul Teknik Üniversitesi\n\n"
                                              + "Galatasaray Üniversitesi\n\n"
                                               + "Marmara Üniversitesi\n\n"
                                                + "Boğaziçi Üniversitesi\n\n"
                                                   + "Acıbadem Üniversitesi\n\n"
                                                   + "Bahçeşehir Üniversitesi\n\n"
                                                   + "Beykent Üniversitesi\n\n"
                                                   + "Bezmialem Vakıf Üniversitesi\n\n"
                                                   + "Doğuş Üniversitesi");*/
                            PromptDialog.Choice(context, this.OnOptionSelected, new List<string>() {
                                "show İstanbul university",
                                "show İstanbul Teknik university" ,
                                "show Galatasaray university" ,
                                "show Marmara university" ,
                                "show Boğaziçi university" ,
                                "show Acıbadem university" ,
                                "show Bahçeşehir university" ,
                                "show Beykent university",
                                "show Bezmialem Vakıf university",
                                "show Doğuş university"
                                 }, 
                                "İstambul'daki Üniversitelerin Listesi", "Not a valid option", 3);
                        }

                         if (searchEntity.Entity == "Ankara" || searchEntity.Entity == "ankara")
                         {

                            /*  await context.PostAsync("Ankara Üniversitesi\n\n"
                                              + "Ankara Sosyal Bilimler Üniversitesi\n\n"
                                               + "Gazi Üniversitesi\n\n"
                                                + "Hacettepe Üniversitesi\n\n"
                                                 + "Orta Doğu Teknik Üniversitesi\n\n"

                                                      + "Anka Teknoloji Üniversitesi\n\n"
                                                    + "Atılım Üniversitesi\n\n"
                                                    + "Başkent Üniversitesi\n\n"
                                                    + "Bilkent Üniversitesi\n\n"
                                                    + "Çankaya Üniversitesi");*/

                            PromptDialog.Choice(context, this.OnOptionSelected, new List<string>() {
                                "show Ankara university",
                                "show Sosyal Bilimler Teknik university" ,
                                "show Gazi university" ,
                                "show Hacettepe university" ,
                                "show Orta Doğu Teknik university" ,
                                "show Anka Teknoloji university" ,
                                "show Atılım university" ,
                                "show Başkent university",
                                "show Bilkent Vakıf university",
                                "show Çankaya university"
                                 },
                                  "Ankara'daki Üniversitelerin Listesi", "Not a valid option", 3);

                        }

                         if (searchEntity.Entity == "İzmir" || searchEntity.Entity == "izmir")
                         {

                             await context.PostAsync("Dokuz Eylül Üniversitesi\n\n"
                                             + "Ege Üniversitesi\n\n"
                                             + "İzmir Demokrasi Üniversitesi\n\n"
                                             + "İzmir Kâtip Çelebi Üniversitesi\n\n"

                                             + "İzmir Ekonomi Üniversitesi\n\n"
                                             + "Türk Hava Kurumu Üniversitesi\n\n"
                                             + "Yaşar Üniversitesi");

                            PromptDialog.Choice(context, this.OnOptionSelected, new List<string>() {
                                "show Dokuz Eylül university",
                                "show Ege university" ,
                                "show İzmir Demokrasi university" ,
                                "show İzmir Kâtip Çelebi university" ,
                                "show İzmir Ekonomi university" ,
                                "show Türk Hava Kurumu university" ,
                                "show Yaşar university" 
                                 },
                                 "İzmir'deki Üniversitelerin Listesi", "Not a valid option", 3);

                        }
                     }
                 }
            }
        }
 
                [LuisIntent("ShowDepartmentInTheUniversity")]
                public async Task ShowCategory(IDialogContext context, LuisResult result)
                {
                    if (result.Entities.Count == 0)
                    {
                        await context.PostAsync("Üzgünüm sonuç bulamadım.");
                    }
                    else
                    {

                        foreach (var searchEntity in result.Entities)
                        {
                            if (searchEntity.Type == "UniversityName")
                            {
                                if (searchEntity.Entity == "İstanbul" || searchEntity.Entity == "İstanbul")
                                {
                                    await context.PostAsync("İstanbul Üni Bölümleri: \n\n"
                                                   + "Cerrahpaşa Tıp Fakültesi\n\n"
                                                   + "Edebiyat Fakültesi\n\n"
                                                   + "Fen Fakültesi\n\n"
                                                   + "Eğitim Fakültesi\n\n"
                                                   + "Florence Nightingale Hemşirelik Fakültesi\n\n"
                                                   + "İktisat Fakültesi\n\n"
                                                   + "İlahiyat Fakültesi\n\n"
                                                   + "İletişim Fakültesi\n\n"
                                                   + "İstanbul Tıp Fakültesi\n\n"
                                                   + "İşletme Fakültesi\n\n"
                                                   + "Mühendislik Fakültesi\n\n"
                                                   + "Orman Fakültesi\n\n"
                                                   + "Sağlık Bilimleri Fakültesi\n\n"
                                                   + "Siyasal Bilgiler Fakültesi\n\n"
                                                   + "Su Ürünleri Fakültesi\n\n"
                                                   + "Ulaştırma ve Lojistik Fakültesi\n\n"
                                                   + "Açık ve Uzaktan Eğitim Fakültesi\n\n");
                                }

                                else if (searchEntity.Entity == "İstanbul Teknik" ||
                                        searchEntity.Entity == "İstanbul teknik" ||
                                        searchEntity.Entity == "istanbul Teknik" ||
                                        searchEntity.Entity == "istanbul teknik")
                                {
                                    await context.PostAsync("İTÜ Bölümleri: \n\n"
                                                    + "İnşaat\n\n"
                                                    + "Mimarlık\n\n"
                                                    + "Makina\n\n"
                                                    + "Elektrik Elektronik\n\n"
                                                    + "Maden/n/n"
                                                    + "Kimya Metalurji/n/n"
                                                    + "İşletme\n\n"
                                                    + "Gemi İnşaatı ve Deniz Bilimleri\n\n"
                                                    + "Fen Edebiyat\n\n"
                                                    + "Uçak ve Uzay Bilimleri\n\n"
                                                    + "Denizcilik\n\n"
                                                    + "Tekstil Teknolojileri ve Tasarımı\n\n"
                                                    + "Bilgisayar ve Bilişim\n\n");


                                }

                                else if (searchEntity.Entity == "Galatasaray" ||
                                        searchEntity.Entity == "galatasaray")
                                {
                                    await context.PostAsync("Galatasaray Uni Bölümleri: \n\n"
                                                    + "Mühendislik ve Teknoloji Fakültesi\n\n"
                                                    + "İletişim Fakültesi\n\n"
                                                    + "İktisadi ve İdari Birimler Fakültesi\n\n"
                                                    + "Fen Edebiyat Fakültesi\n\n"
                                                    + "Hukuk Fakültesi\n\n"
                                                    + "Fen Bilimleri Enstitüsü\n\n"
                                                    + "Sosyal Bilimler Enstitüsü\n\n");


                                }


                                else if (searchEntity.Entity == "Ankara Sosyal Bilimler"
                                    || searchEntity.Entity == "Ankara sosyal bilimler")
                                {
                                    await context.PostAsync("Ankara Sosyal Bilimler Uni Bölümleri: \n\n"
                                                   + "Dini İlimler Fakültesi\n\n"
                                                   + "Hukuk Fakültesi\n\n"
                                                   + "Siyasal Bilgiler Fakültesin\n"
                                                   + "Sosyal ve Beşeri Bilimler Fakültesi\n\n"
                                                   + "Yabancı Diller Fakültesi\n\n");
                                }

                                else if (searchEntity.Entity == "Gazi"
                                || searchEntity.Entity == "gazi")
                                {
                                    await context.PostAsync("Gazi Üniversitesindeki Fakülteler: \n\n"
                                                   + "Diş Hekimliği Fakültesi\n\n"
                                                   + "Eczacılık Fakültesi\n\n"
                                                   + "Edebiyat Fakültesi\n\n"
                                                   + "Fen Fakültesi\n\n"
                                                   + "Gazi Eğitim Fakültesi Fakültesi\n\n"
                                                   + "Güzel Sanatlar Fakültesi\n\n"
                                                   + "Hukuk Fakültesi\n\n"
                                                   + "İktisadi ve İdari Bilimler Fakültesi\n\n"
                                                   + "İletişim Fakültesi\n\n"
                                                   + "Mimarlık Fakültesi\n\n"
                                                   + "Mühendislik Fakültesi\n\n"
                                                   + "Sağlık Bilimleri Fakültesi\n\n"
                                                   + "Sanat ve Tasarım Fakültesi\n\n"
                                                   + "Spor Bilimleri Fakültesi\n\n"
                                                   + "Teknoloji Fakültesi\n\n"
                                                   + "Tıp Fakültesi\n\n"
                                                   + "Turizm Fakültesi\n\n"
                                                   + "Uygulamalı Bilimler Fakültesi\n\n");

                                }


                                else if (searchEntity.Entity == "Dokuz Eylül" ||
                                        searchEntity.Entity == "Dokuz eylül" ||
                                        searchEntity.Entity == "dokuz eylül")
                                {
                                    await context.PostAsync("Dokuz Eylül fakülteleri"
                                                    + "Mimarlık Fakültesi\n\n"
                                                    + "Diş Hekimliği Fakültesi\n\n"
                                                    + "Denizcilik Fakültesi\n\n"
                                                    + "Eğitim Bilimleri Fakültesi\n\n"
                                                    + "Fen Fakültesi/n/n"
                                                    + "Güzel Sanatlar Fakültesi/n/n"
                                                    + "Hukuk Fakültesi\n\n"
                                                    + "İlahiyat Fakültesi\n\n"
                                                    + "İşletme Fakültesi\n\n"
                                                    + "Mühendislik Fakültesi\n\n"
                                                    + "İktisadi ve İdariBilimler Fakültesi\n\n"
                                                    + "Tıp Fakültesi\n\n");
                                }



                                else if (searchEntity.Entity == "Ege"
                                || searchEntity.Entity == "ege")
                                {
                                    await context.PostAsync("Ege Üniversitesindeki Fakülteler: \n\n"
                                                   + "Diş Hekimliği Fakültesi\n\n"
                                                   + "Eczacılık Fakültesi\n\n"
                                                   + "Edebiyat Fakültesi\n\n"
                                                   + "Eğitim Fakültesi\n\n"
                                                   + "Fen Fakültesi\n\n"
                                                   + "İktisadi ve İdari Bilimler Fakültesi\n\n"
                                                   + "Güzel Sanatlar Tasarım ve Mimarlık Fakültesi\n\n"
                                                   + "İletişim Fakültesi\n\n"
                                                   + "Sağlık Bilimleri Fakültesi\n\n"
                                                   + "Spor Bilimleri Fakültesi\n\n"
                                                   + "Su Ürünleri Fakültesi\n\n"
                                                   + "Tıp Fakültesi\n\n"
                                                   + "Ziraat Fakültesi\n\n");
                                }

                                else if (searchEntity.Entity == "İzmir Demokrasi"
                                        || searchEntity.Entity == "izmir demokrasi"
                                        || searchEntity.Entity == "İzmir demokrasi")
                                {
                                    await context.PostAsync("İzmir Demokrasi Üniversitesindeki Fakülteler: \n\n"
                                                   + "Diş Hekimliği Fakültesi\n\n"
                                                   + "Fen Edebiyat Fakültesi\n\n"
                                                   + "Eğitim Fakültesi\n\n"
                                                   + "Hukuk Fakültesi\n\n"
                                                   + "İktisadi ve İdari Bilimler Fakültesi\n\n"
                                                   + "Güzel Sanatlar Fakültesi\n\n"
                                                    + "Sağlık Bilimleri Fakültesi\n\n"
                                                   + "Mimarlık Fakültesi\n\n"
                                                   + "Tıp Fakültesi\n\n"
                                                   + "Mühendislik Fakültesi\n\n");
                                }

                                else
                                {

                                    await context.PostAsync(($"{searchEntity.Entity} için sonuç bulunamadı."));

                                }

                                    //üniversitedeki bölümler eklenecek

                            }
                        }
                    }
                }


                public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
                {
                    var message = await result;

                    if (message.Text.ToLower().Contains("help") || message.Text.ToLower().Contains("support") || message.Text.ToLower().Contains("problem"))
                    {
                        // await context.Forward(new SupportDialog(), this.ResumeAfterSupportDialog, message, CancellationToken.None);
                    }
                    else
                    {
        //                this.ShowOptions(context);
                    }
                }

                private async Task ResumeAfterOptionDialog(IDialogContext context, IAwaitable<object> result)
                {
                    try
                    {
                        var message = await result;
                    }
                    catch (Exception ex)
                    {
                        await context.PostAsync($"Failed with message: {ex.Message}");
                    }
                    finally
                    {
                        context.Wait(this.MessageReceivedAsync);
                    }
                }
    }
}
