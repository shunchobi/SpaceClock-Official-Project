//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Firebase.Analytics;

//public class Analyser : MonoBehaviour {



//	public enum ScreenName {
//        None,
//        TopFromGame,
//        TopFromCleared,
//        Statistics,
//        Game,
//        Replay,
//        JustCleared,
//        ScoreCleared,
//        HowTo,
//        Setting,
//        Store,
//    }


//    ///そのままメソッドを呼べば、Firebaseにデータが送信される。
//    /// <summary>
//    /// 表示したシーンの記録
//    /// </summary>
//    public static void ChangeScreen(ScreenName screen)
//    {
//        string name = "screen_" + screen.ToString();
//        FirebaseAnalytics.SetCurrentScreen(name, name);
//    }




//    /// <summary>
//    /// イベント名：scan_uesd
//    /// パラメーター名：num_of_scaned
//    /// 今までにスキャンを使用した回数：number
//    /// </summary>
//    public static void ScanUsed(int number)
//    {
//        FirebaseAnalytics.LogEvent("scan_uesd", "num_of_scaned", number);
//    }





//    /// <summary>
//    /// イベント名：game_played
//    /// パラメーター名：num_of_game
//    /// 今までにプレイした回数：number
//    /// </summary>
//    public static void GamePlayed(int number)/////
//    {
//        FirebaseAnalytics.LogEvent("game_played", "num_of_game", number);
//    }


//    public static void GamesWon(int gamesWon)
//    {
//        FirebaseAnalytics.LogEvent("games_won", "num_of_won", gamesWon);
//    }



//    /// <summary>
//    /// イベント名：play_style
//    /// パラメーター名：one_or_three
//    /// 一枚か三枚か：style
//    /// </summary>
//    public static void PlayStyle(bool isOneFlip)
//    {
//        string style = "";
//        if (isOneFlip == true)
//            style = "one_flip";
//        else
//            style = "three_flip";

//        FirebaseAnalytics.LogEvent("play_style", "one_or_three", style);
//    }




//    public static void FlipOneScaned(int scanedNum)///
//    {
//        FirebaseAnalytics.LogEvent("scaned_with_flip_one", "num_of_scaned", scanedNum);
//    }


//    public static void FlipThreeScaned(int scanedNum)///
//    {

//        FirebaseAnalytics.LogEvent("scaned_with_flip_three", "num_of_scaned", scanedNum);
//    }








//    public static string shown_interstitial_game = "shown_interstitial_game";
//    public static string shown_interstitial_clear = "shown_interstitial_clear";
//    public static string touched_interstitial_game = "touch_interstitial_game";
//    public static string touched_interstitial_clear = "touch_interstitial_clear";
//    /// <summary>
//    /// イベント名：どこで全画面広告が出されたか、全画面広告が押されたとき
//    /// </summary>
//    public static void InterstitialAd(string interstitialAd)
//    {
        
//        FirebaseAnalytics.LogEvent(interstitialAd);
//    }



//    /// <summary>
//    /// クリア後に動画広告を提示した回数
//    /// </summary>
//    public static void SuggestedClearedRewardAd()
//    {
//        FirebaseAnalytics.LogEvent("suggested_cleared_reward_ad");
//    }



//    /// <summary>
//    /// クリア後に提示した動画広告が押された回数
//    /// </summary>
//    public static void TouchedCleardRewardAd()
//    {
//        FirebaseAnalytics.LogEvent("touched_cleared_reward_ad");
//    }



//    /// <summary>
//    /// ストアの動画広告が押された回数
//    /// </summary>
//    public static void TouchedStoreRewardAd()
//    {
//        FirebaseAnalytics.LogEvent("touched_store_reward_ad");
//    }


//    public static string store_free = "store_free";
//    public static string store_10 = "store_10";
//    public static string store_24 = "store_24";
//    public static string store_80 = "store_80";
//    public static string store_200 = "store_200";
//    /// <summary>
//    /// イベント名：何が購入されたか
//    /// </summary>
//    public static void SelectedStoreContent(string content)
//    {
//        FirebaseAnalytics.LogEvent(content);
//    }
//}
