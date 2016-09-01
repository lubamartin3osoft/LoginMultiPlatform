﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using LoginMultiPlatform.Core.Abstracts;
using LoginMultiPlatform.Core.Data;
using LoginMultiPlatform.Core.Services;
using LoginMultiPlatform.Core.Utilities;
using LoginMultiPlatform.iOS.ViewControlers;
using UIKit;

namespace LoginMultiPlatform.iOS
{
   public class ApplicationSessionContext : IApplicationSessionContext
   {     
      private static ApplicationSessionContext _instance;
      private IUserRepository _userRepository;
      private UINavigationController _navigationController;

      public static ApplicationSessionContext Instance =>
         _instance ?? (_instance = new ApplicationSessionContext());

      public User User { get; private set; }

      public async Task LogOutAsync()
      {
         await _userRepository.DeleteEmailAsync(User);
         
      }      

      public async Task StoreUserAsync(User user)
      {
         User = user;         
         await _userRepository.InsertEmailAsync(user);
         _navigationController.SetViewControllers(new UIViewController[] { new LoginViewControler() }, false);
      }

      public void InitializeNavigationController(UINavigationController navigationController)
      {
         _navigationController = navigationController;
      }

      public async Task InitializeConextAsync(IUserRepository userRepository)
      {
         _userRepository = userRepository;
         User = await userRepository.GetUserlAsync();
      }

      public async Task InitializeConextAsync()
      {
         _userRepository = BaseContainer.Instance.GetInstance<IUserRepository>();
         User = await _userRepository.GetUserlAsync();
      }
   }
}