using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Database;
using Firebase.Database.Query;
using FlashDelivery.Class.Bean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashDelivery.Class
{
    public class FirebaseHelpdesk
    {
        FirebaseClient firebase = new FirebaseClient(CmmVariable.URL_Firebase);
        public async Task RegisterUser(BeanUser user)
        {

            await firebase
              .Child("BeanUser")
              .PostAsync(user);
        }
        public async Task AddItem(BeanItemDetails beanItemDetails)
        {

            await firebase
              .Child("BeanListDashBoard")
              .PostAsync(beanItemDetails);
        }

        public async Task<List<BeanUser>> GetAllPersonsAsync()
        {

            return (await firebase
              .Child("BeanUser")
              .OnceAsync<BeanUser>()).Select(item => new BeanUser
              {
                  fullName = item.Object.fullName,
                  birthDay=item.Object.birthDay,
                  Location=item.Object.Location,
                  passWord= item.Object.passWord,
                  phoneNumber=item.Object.phoneNumber,
                  sex=item.Object.sex,
                  type=item.Object.type,
                  username=item.Object.username
                  
              }).ToList();
        }
        public async Task<List<BeanItemDetails>> GetAllBeanListDashBoard()
        {

            return (await firebase
              .Child("BeanListDashBoard")
              .OnceAsync<BeanItemDetails>()).Select(item => new BeanItemDetails
              {
                 key=item.Key,
                 pakage_Name=item.Object.pakage_Name,
                 kilomet = item.Object.kilomet,
                 ListItemChild = item.Object.ListItemChild,
                 location = item.Object.location,
                 Money = item.Object.Money

              }).ToList();
        }
        public async Task<List<BeanItemDetails>> GetAllBeanListShip()
        {

            return (await firebase
              .Child("BeanListShip")
              .OnceAsync<BeanItemDetails>()).Select(item => new BeanItemDetails
              {
                  user=item.Object.user,
                  pass=item.Object.pass,
                  key = item.Key,
                  pakage_Name = item.Object.pakage_Name,
                  kilomet = item.Object.kilomet,
                  ListItemChild = item.Object.ListItemChild,
                  location = item.Object.location,
                  Money = item.Object.Money

              }).ToList();
        }

        public async Task AddItemToListShip(BeanItemShip beanItemDetails)
        {

            await firebase
              .Child("BeanListShip")
              .PostAsync(beanItemDetails);
        }
        public async Task DeleteItemToListDashBoard(BeanItemDetails beanItemDetails)
        {
            List<BeanItemDetails> temp = await GetAllBeanListDashBoard();
            temp = temp.Where(x => 
            x.pakage_Name == beanItemDetails.pakage_Name
            && x.location==beanItemDetails.location
            &&x.kilomet==beanItemDetails.kilomet
            &&x.Money==beanItemDetails.Money
            &&x.ListItemChild==x.ListItemChild
            ).ToList();
            await firebase
              .Child("BeanListDashBoard").Child(temp[0].key).DeleteAsync();
        }

        public async Task AddItemToReport(BeanReport beanReport)
        {
            await firebase
              .Child("BeanReport")
              .PostAsync(beanReport);
        }

        public async Task DeleteItemListShipToMoveReport(BeanItemDetails beanItemDetails)
        {
            List<BeanItemDetails> temp = await GetAllBeanListShip();
            temp = temp.Where(x =>
            x.pakage_Name == beanItemDetails.pakage_Name && x.user==beanItemDetails.user
            ).ToList();
            await firebase
              .Child("BeanListShip").Child(temp[0].key).DeleteAsync();
        }
    }
}