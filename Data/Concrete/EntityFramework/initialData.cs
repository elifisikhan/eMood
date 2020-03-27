using Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Concrete.EntityFramework
{
    public static class initialData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices
                .GetRequiredService<eMoodContext>();

            context.Database.Migrate(); // bekleyen migration varsa çalıştırma
            using (var transaction = context.Database.BeginTransaction())
            {
                if (!context.Activities.Any())
                {
                    var emotions = new[]
                    {
                    new Emotion() {  EmotionName = "Mutlu" },
                    new Emotion() {  EmotionName = "Üzgün" },
                    new Emotion() { EmotionName = "Kızgın" },
                    new Emotion() {  EmotionName = "Korkmuş" },
                    new Emotion() {  EmotionName = "Bıkmış" },
                };
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Emotions] ON");
                    context.SaveChanges();
                    context.Emotions.AddRange(emotions);
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Emotions] OFF");

                    

                    var activities = new[]
                    {
                    new Activity(){  ActivityName="Film"},
                    new Activity(){ ActivityName="Müzik"},
                    new Activity(){  ActivityName="Dizi"},
                    new Activity(){  ActivityName="Bisiklet"},
                    new Activity(){  ActivityName="Sinema"},
                    new Activity(){  ActivityName="Belgesel"},
                    new Activity(){ ActivityName="e-Book"},
                    new Activity(){  ActivityName="Oyun",},
                    new Activity(){  ActivityName="Alışveriş"},
                    new Activity(){  ActivityName="Yürüyüş"}
                };
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Activities] ON");
                    context.SaveChanges();
                    context.Activities.AddRange(activities);
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Activities] OFF");

                    transaction.Commit();


                    var activityattributes = new[]
                    {
                    new ActivityAttribute(){  AttributeName ="Amelie", Image="amelie.jpg", Rate=8, Description ="askldjkas", Activity=activities[0],Emotion=emotions[1], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Beni Sen İnandır", Image="pinhani.jpg", Rate=8, Description ="askldjkas", Activity=activities[1],Emotion=emotions[1], InInside=true},
                    new ActivityAttribute(){  AttributeName ="La Casa De Papel", Image="lcdp.jpg", Rate=8, Description ="la casa de papel 1. sezon", Activity=activities[2],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="bisiklet sürrme 1", Image="bike.jpg", Rate=8, Description ="bisiklet 1. sezon", Activity=activities[3],Emotion=emotions[1], InInside=true},
                    new ActivityAttribute(){  AttributeName ="cinemaximum", Image="cinema.jpg", Rate=8, Description ="sinemaa1. sezon", Activity=activities[4],Emotion=emotions[1], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Cosmos", Image="cosmos.jpg", Rate=8, Description ="dünya tarihi", Activity=activities[5],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="e-kitap fareler ve insanlar", Image="fvi.jpg", Rate=8, Description ="ekitap oku", Activity=activities[6],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="skyrim", Image="skyrim.jpg", Rate=8, Description ="elder scroll", Activity=activities[7],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="troia avm", Image="troia.jpg", Rate=8, Description ="avmmm", Activity=activities[8],Emotion=emotions[1], InInside=true},
                    new ActivityAttribute(){  AttributeName ="gelibolu yürüyüşü", Image="walk.jpg", Rate=8, Description ="yürüyüş festivali", Activity=activities[9],Emotion=emotions[1], InInside=true},
                };
                    context.ActivityAttributes.AddRange(activityattributes);

                    var activityEmotions = new[]
                    {
                    new ActivityEmotion(){ Activity = activities[0], Emotion=emotions[0]},
                    new ActivityEmotion(){ Activity = activities[1], Emotion=emotions[0]},
                    new ActivityEmotion(){ Activity = activities[2], Emotion=emotions[0]},
                    new ActivityEmotion(){ Activity = activities[3], Emotion=emotions[0]},
                    new ActivityEmotion(){ Activity = activities[4], Emotion=emotions[0]},
                    new ActivityEmotion(){ Activity = activities[5], Emotion=emotions[0]},
                    new ActivityEmotion(){ Activity = activities[6], Emotion=emotions[0]},
                    new ActivityEmotion(){ Activity = activities[7], Emotion=emotions[0]},
                    new ActivityEmotion(){ Activity = activities[8], Emotion=emotions[0]},
                    new ActivityEmotion(){ Activity = activities[9], Emotion=emotions[0]},

                    new ActivityEmotion(){ Activity = activities[0], Emotion=emotions[1]},
                    new ActivityEmotion(){ Activity = activities[1], Emotion=emotions[1]},
                    new ActivityEmotion(){ Activity = activities[2], Emotion=emotions[1]},
                    new ActivityEmotion(){ Activity = activities[3], Emotion=emotions[1]},
                    new ActivityEmotion(){ Activity = activities[4], Emotion=emotions[1]},
                    new ActivityEmotion(){ Activity = activities[5], Emotion=emotions[1]},
                    new ActivityEmotion(){ Activity = activities[6], Emotion=emotions[1]},
                    new ActivityEmotion(){ Activity = activities[7], Emotion=emotions[1]},
                    new ActivityEmotion(){ Activity = activities[8], Emotion=emotions[1]},
                    new ActivityEmotion(){ Activity = activities[9], Emotion=emotions[1]},

                    new ActivityEmotion(){ Activity = activities[0], Emotion=emotions[2]},
                    new ActivityEmotion(){ Activity = activities[1], Emotion=emotions[2]},
                    new ActivityEmotion(){ Activity = activities[2], Emotion=emotions[2]},
                    new ActivityEmotion(){ Activity = activities[3], Emotion=emotions[2]},
                    new ActivityEmotion(){ Activity = activities[4], Emotion=emotions[2]},
                    new ActivityEmotion(){ Activity = activities[5], Emotion=emotions[2]},
                    new ActivityEmotion(){ Activity = activities[6], Emotion=emotions[2]},
                    new ActivityEmotion(){ Activity = activities[7], Emotion=emotions[2]},
                    new ActivityEmotion(){ Activity = activities[8], Emotion=emotions[2]},
                    new ActivityEmotion(){ Activity = activities[9], Emotion=emotions[2]},

                    new ActivityEmotion(){ Activity = activities[0], Emotion=emotions[3]},
                    new ActivityEmotion(){ Activity = activities[1], Emotion=emotions[3]},
                    new ActivityEmotion(){ Activity = activities[2], Emotion=emotions[3]},
                    new ActivityEmotion(){ Activity = activities[3], Emotion=emotions[3]},
                    new ActivityEmotion(){ Activity = activities[4], Emotion=emotions[3]},
                    new ActivityEmotion(){ Activity = activities[5], Emotion=emotions[3]},
                    new ActivityEmotion(){ Activity = activities[6], Emotion=emotions[3]},
                    new ActivityEmotion(){ Activity = activities[7], Emotion=emotions[3]},
                    new ActivityEmotion(){ Activity = activities[8], Emotion=emotions[3]},
                    new ActivityEmotion(){ Activity = activities[9], Emotion=emotions[3]},

                    new ActivityEmotion(){ Activity = activities[0], Emotion=emotions[4]},
                    new ActivityEmotion(){ Activity = activities[1], Emotion=emotions[4]},
                    new ActivityEmotion(){ Activity = activities[2], Emotion=emotions[4]},
                    new ActivityEmotion(){ Activity = activities[3], Emotion=emotions[4]},
                    new ActivityEmotion(){ Activity = activities[4], Emotion=emotions[4]},
                    new ActivityEmotion(){ Activity = activities[5], Emotion=emotions[4]},
                    new ActivityEmotion(){ Activity = activities[6], Emotion=emotions[4]},
                    new ActivityEmotion(){ Activity = activities[7], Emotion=emotions[4]},
                    new ActivityEmotion(){ Activity = activities[8], Emotion=emotions[4]},
                    new ActivityEmotion(){ Activity = activities[9], Emotion=emotions[4]},


                };
                    context.ActivityEmotions.AddRange(activityEmotions);
                    context.SaveChanges();
                }
            }
        }
    }
}

 