using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Query;
using YF.MWS.SQliteService;
using YF.Utility.Cache;

namespace YF.MWS.CacheService
{
    /// <summary>
    /// 计划卡缓存
    /// </summary>
    public class CardCacher
    {
        private static string cardKey = "card:";

        /// <summary>
        /// 获取计划卡信息
        /// </summary>
        /// <returns></returns>
        public static List<QPlanCard> GetList() 
        {
            string key = cardKey + "list";
            List<QPlanCard> lstCard = new List<QPlanCard>();
            if (CacheFactory.CacheInstance.Contains(key))
            {
                lstCard = (List<QPlanCard>)CacheFactory.CacheInstance.Get(key);
            }
            if (lstCard == null || lstCard.Count==0)
            {
                ICardService cardService = new CardService();
                lstCard = cardService.GetList();
                CacheFactory.CacheInstance.Add(key, lstCard,5);
            }
            return lstCard;
        }

        /// <summary>
        /// 获取所有预设的计划卡数据
        /// </summary>
        /// <returns></returns>
        public static List<BCardPreset> GetPresetList() 
        {
            string key = cardKey + "preset:list";
            List<BCardPreset> lstCard = new List<BCardPreset>();
            if (CacheFactory.CacheInstance.Contains(key))
            {
                lstCard = (List<BCardPreset>)CacheFactory.CacheInstance.Get(key);
            }
            if (lstCard == null || lstCard.Count==0)
            {
                ICardService cardService = new CardService();
                lstCard = cardService.GetPresetList();
                CacheFactory.CacheInstance.Add(key, lstCard, 5);
            }
            return lstCard;
        }

        /// <summary>
        /// 根据卡ID获取计划卡的预设数据
        /// </summary>
        /// <param name="cardId"></param>
        /// <returns></returns>
        public static List<BCardPreset> GetPresetList(string cardId) 
        {
            List<BCardPreset> lstFind = null;
            List<BCardPreset> lstPreset= GetPresetList();
            if (lstPreset != null && lstPreset.Count > 0) 
            {
                lstFind = lstPreset.FindAll(c => c.CardId == cardId);
            }
            return lstFind;
        }

        /// <summary>
        /// 根据卡号ID获取计划卡
        /// </summary>
        /// <param name="carNo"></param>
        /// <returns></returns>
        public static QPlanCard Get(string cardId, ICardService cardService,bool fromCache=true)
        {
            QPlanCard card = null;
            if (fromCache)
            {
                string key = string.Format("{0}:id:{1}", cardKey, cardId);
                if (CacheFactory.CacheInstance.Contains(key))
                {
                    card = (QPlanCard)CacheFactory.CacheInstance.Get(key);
                }
                if (card == null)
                {
                    card = cardService.Get(cardId);
                    if (card != null)
                    {
                        CacheFactory.CacheInstance.Add(key, card, Consts.CACHE_TIME_OUT_TWO_HOURS);
                    }
                }
            }
            else 
            {
                card = cardService.Get(cardId);
            }
            return card;
        }

        /// <summary>
        /// 根据车牌号获取计划卡
        /// </summary>
        /// <param name="carNo"></param>
        /// <returns></returns>
        public static QPlanCard GetWithCarNo(string carNo)
        {
            QPlanCard card = null;
            List<QPlanCard> lstCard= GetList();
            if (lstCard != null && lstCard.Count > 0) 
            {
                card = lstCard.Find(c => c.CarNo == carNo);
            }
            return card;
        }

        /// <summary>
        /// 根据卡号获取计划卡
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public static QPlanCard GetWithCardNo(ICardService cardService,string cardNo,bool fromCache=true)
        {
            QPlanCard card = null;
            if (fromCache)
            {
                List<QPlanCard> lstCard = GetList();
                if (lstCard != null && lstCard.Count > 0)
                {
                    card = lstCard.Find(c => c.CardNo == cardNo);
                }
            }
            else 
            {
                card = cardService.GetWithCardNo(cardNo);
            }
            return card;
        }

        /// <summary>
        /// 刷新缓存
        /// </summary>
        public static void Refresh() 
        {
            string key = cardKey + "list";
            CacheFactory.CacheInstance.Delete(key);
            GetList();
            key = cardKey + "preset:list";
            CacheFactory.CacheInstance.Delete(key);
            GetPresetList();
        }

        /// <summary>
        /// 初始化计划卡缓存
        /// </summary>
        public static void InitCacher() 
        {
            GetList();
            GetPresetList();
        }
    }
}
