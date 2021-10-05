namespace BikeSharing.Application
{
    public static class SharedData
    {
        #region Messages
        public static string LogMessageRequestReceived = "İstek alındı!";
        public static string LogMessageSelectSuccess = "Veriler veritabanından okundu!";
        public static string LogMessageInsertSuccess = "Veriler veritabanına yazıldı!";
        
        public static string MessageUsersNotFound = "Kullanıcılar bulunamadı!";
        public static string MessageUserNotFound = "Kullanıcı bulunamadı!";
        public static string MessageSessionsNotFound = "Session bulunamadı!";
        public static string MessageSessionNotFound = "Session bulunamadı!";
        public static string MessageCantCreateUser = "Kullanıcı eklenemedi";
        public static string MessageCantCreateSession = "Session eklenemedi";
        public static string MessageCantUpdateUser = "Kullanıcı güncellenemedi";
        public static string MessageCantUpdateSession = "Session güncellenemedi";
        #endregion

        public const string LogSeperator = "=======================================================================================================================================================================================";

    }
}