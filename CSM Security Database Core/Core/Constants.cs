namespace CSM_Security_Database_Core.Core;

/// <summary>
/// 
/// </summary>
static class Constants {

    public struct Connectors {
        /// <summary>
        /// 
        /// </summary>
        public struct UsersPermits {
            /// <summary>
            /// 
            /// </summary>
            public const string Connector = "Users_Permits";
            /// <summary>
            /// 
            /// </summary>
            public const string User = "User";
            /// <summary>
            /// 
            /// </summary>
            public const string Permit = "Permit";
        }

        /// <summary>
        /// 
        /// </summary>
        public struct UsersProfiles {
            /// <summary>
            /// 
            /// </summary>
            public const string Connector = "Users_Profiles";
            /// <summary>
            /// 
            /// </summary>
            public const string User = "User";
            /// <summary>
            /// 
            /// </summary>
            public const string Profile = "Profile";
        }

        /// <summary>
        /// 
        /// </summary>
        public struct UsersVendors {
            /// <summary>
            /// 
            /// </summary>
            public const string Connector = "Users_Vendors";
            /// <summary>
            /// 
            /// </summary>
            public const string User = "User";
            /// <summary>
            /// 
            /// </summary>
            public const string Vendor = "Vendor";
        }

        /// <summary>
        /// 
        /// </summary>
        public struct PermitsProfiles {
            /// <summary>
            /// 
            /// </summary>
            public const string Connector = "Profiles_Permits";
            /// <summary>
            /// 
            /// </summary>
            public const string Permit = "Permit";
            /// <summary>
            /// 
            /// </summary>
            public const string Profile = "Profile";
        }
    }
}
