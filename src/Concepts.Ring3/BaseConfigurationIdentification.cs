using System;
using System.Collections.Generic;
using System.Text;

namespace Concepts.Ring3
{
    /// <summary>
    /// This abstract class contains constant numeric id´s for configuration values. 
    /// </summary>
    /// <remarks>
    /// The numeric serie begins at 1301.
    /// Do not use same id twice.
    /// </remarks>
    /// <example>
    /// ListConfigurationParameter.Kind listkind = ConfigurationHelper.AssureListKind(ConfigurationIdentifiation.POSKey, "CONFPAR_POSKey", "CONFDESC_POSKey");
    /// ListConfigurationParameter param = ConfigurationHelper.AssureListConfiguration(ConfigurationIdentifiation.POSKey, system, typeof(BaseDefinitions));
    /// </example>
    public abstract class BaseConfigurationIdentification
    {
        //public const Int64 POSKey = 1301;
        public const Int64 ProductSeekerNrOfRows = 1302;
        public const Int64 NIBTestLongParam = 1303;
        public const Int64 POSUpdateCustomerDisplay = 1304;
        public const Int64 PrintableOrder = 1305;
        public const Int64 PrintableSomebody = 1306;
        public const Int64 PrintableDelivery = 1308;


        //Ring 3
        public const Int64 CONFPAR_CLAIMSUBSTATUS = 3001L;
        public const Int64 CONFPAR_TENDER = 3004L;
        public const Int64 CONFPAR_BAUD = 3005L;
        public const Int64 CONFPAR_DATABITS = 3006L;
        public const Int64 CONFPAR_FLOWCONTROL = 3007L;
        public const Int64 CONFPAR_NOPINS = 3008L;
        public const Int64 CONFPAR_PARITY = 3009L;
        public const Int64 CONFPAR_PORT = 3010L;
        public const Int64 CONFPAR_STOPBITS = 3011L;
        public const Int64 CONFPAR_AbsenceReason = 3012L;
        public const Int64 CONFPAR_ACCOUNT = 3013L;
        public const Int64 CONFPAR_ADDRESS_ROLES = 3014L;
        public const Int64 CONFPAR_CATEGORY = 3016L;
        public const Int64 CONFPAR_ChargeReason = 3017L;
        public const Int64 CONFPAR_CITIES = 3018L;
        public const Int64 CONFPAR_COLOR = 3019L;
        public const Int64 CONFPAR_COUNTRIES = 3020L;
        public const Int64 CONFPAR_CURRENCIES = 3021L;
        public const Int64 CONFPAR_CUSTOMERGROUP = 3022L;
        public const Int64 CONFPAR_DeliveryReason = 3023L;
        public const Int64 CONFPAR_DiscountReason = 3024L;
        public const Int64 CONFPAR_ENERGY_UNIT = 3025L;
        public const Int64 CONFPAR_FILES = 3026L;
        public const Int64 CONFPAR_ISBNKINDS = 3027L;
        public const Int64 CONFPAR_ISBNRANGES = 3028L;
        public const Int64 CONFPAR_LANGUAGES = 3029L;
        public const Int64 CONFPAR_LENGTH_UNIT = 3030L;
        public const Int64 CONFPAR_MASS_UNIT = 3031L;
        public const Int64 CONFPAR_MESSAGE_TYPES = 3032L;
        public const Int64 CONFPAR_PACKAGE_TEMPLATE = 3033L;
        public const Int64 CONFPAR_PaymentTerm = 3034L;
        public const Int64 CONFPAR_POSTCODES = 3035L;
        public const Int64 CONFPAR_PRINTERS = 3036L;
        public const Int64 CONFPAR_PRIORITIES = 3037L;
        public const Int64 CONFPAR_REASON = 3038L;
        public const Int64 CONFPAR_ServiceReason = 3039L;
        public const Int64 CONFPAR_STOREGROUP = 3040L;
        public const Int64 CONFPAR_SYSTEMUSERGROUP = 3041L;
        public const Int64 CONFPAR_TEMPERATURE_UNIT = 3042L;
        public const Int64 CONFPAR_TillBalanceReductionReason = 3043L;
        public const Int64 CONFPAR_UNITOFMEASUREs = 3044L;
        public const Int64 CONFPAR_UNITOFTRADEABLEKINDS = 3045L;
        public const Int64 CONFPAR_VendibleAttribute = 3046L;
        public const Int64 CONFPAR_RECEIVING_STOCKPLACE = 3047L;
        public const Int64 CONFPAR_DELIVERY_STOCKPLACE = 3048L;
        public const Int64 CONFPAR_DELIVERYMETHOD = 3049L;
        public const Int64 CONFPAR_CUSTOMEREVENTS = 3050L;
        public const Int64 CONFPAR_ValidPeriod = 3051L;
        public const Int64 CONFPAR_CompanyCustomerDefaultNumberKind = 3052L;
        public const Int64 CONFPAR_PersonCustomerDefaultNumberKind = 3053L;
        public const Int64 CONFPAR_SalesProbability = 3054L;
        public const Int64 CONFPAR_MAIN_SEEKER_PLUGINS = 3055L;
        public const Int64 CONFPAR_StockCorrectionReason = 3056L;
    }
}
