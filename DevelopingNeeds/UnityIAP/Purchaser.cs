using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;



namespace CompleteProject
{
    public class Purchaser : MonoBehaviour, IStoreListener
    {
        private static IStoreController m_StoreController;
        private static IExtensionProvider m_StoreExtensionProvider;

        public static string productId_NoAds = "com.onewheat.purchacefornoads";
        private static string appIdApple = "com.one-wheat.SpaceClock";

        public string price = "";

        void Start()
        {
            if (m_StoreController == null)
            {
                InitializePurchasing();
            }

            Debug.Log("price1 = "+m_StoreController.products.all[0].metadata.localizedPriceString);
            Debug.Log("price1_2 = " + m_StoreController.products.WithID(productId_NoAds).metadata.localizedPriceString);

        }


        public void InitializePurchasing()
        {
            if (IsInitialized())
                return;

            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
            builder.AddProduct(productId_NoAds, ProductType.NonConsumable);

            UnityPurchasing.Initialize(this, builder);
        }


        private bool IsInitialized()
        {
            return m_StoreController != null && m_StoreExtensionProvider != null;
        }


        public void PurchaseForNoAds()
        {
            BuyProductID(productId_NoAds);
        }



        void BuyProductID(string productId)
        {
            if (IsInitialized())
            {
                Product product = m_StoreController.products.WithID(productId);

                if (product != null && product.availableToPurchase)
                {
                    Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                    m_StoreController.InitiatePurchase(product);
                }
                else
                {
                    Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
                }
            }
            else
            {
                Debug.Log("BuyProductID FAIL. Not initialized.");
            }
        }


        public void RestorePurchases()
        {
            if (!IsInitialized())
            {
                Debug.Log("RestorePurchases FAIL. Not initialized.");
                return;
            }

            if (Application.platform == RuntimePlatform.IPhonePlayer ||
                Application.platform == RuntimePlatform.OSXPlayer)
            {
                Debug.Log("RestorePurchases started ...");

                var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
                apple.RestoreTransactions((result) =>
                {
                    Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
                });
            }
            else
            {
                Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
            }
        }



        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            Debug.Log("OnInitialized: PASS");

            m_StoreController = controller;
            m_StoreExtensionProvider = extensions;


            Debug.Log("price1 = " + controller.products.all[0].metadata.localizedPriceString);
            Debug.Log("price2 = " + controller.products.WithID(productId_NoAds).metadata.localizedPriceString);
            Debug.Log("money code = " + controller.products.WithID(productId_NoAds).metadata.isoCurrencyCode);

            price = controller.products.WithID(productId_NoAds).metadata.localizedPriceString;



            ////////////////restore//////////////
            //extensions.GetExtension<IAppleExtensions>().RestoreTransactions(result => {
            //    if (result)
            //    {
            //        // リストア成功時の処理を書く
            //        Debug.Log("Restore Success.");
            //    }
            //    else
            //    {
            //        // リストア失敗時の処理を書く
            //        Debug.Log("Restore Failed.");
            //    }
            //});
            ////////////////restore//////////////
        }


        public void OnInitializeFailed(InitializationFailureReason error)
        {
            Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
        }


        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
        {
            if (String.Equals(args.purchasedProduct.definition.id, productId_NoAds, StringComparison.Ordinal))
            {
                Cash.preference.hasPurchased = true;
                if(Cash.preference.rewardWatched == true)
                    Cash.rewardDealer.CancelRewardAds();
                SaveManager.SaveFile_Preference();

                GameObject.Find("SettingOpener").GetComponent<SettingMenuOpener>().PutStikers();

                Debug.Log("購入完了");
            }

            else
            {
                Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
            }

            return PurchaseProcessingResult.Complete;
        }




        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
            Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
        }



    }
}