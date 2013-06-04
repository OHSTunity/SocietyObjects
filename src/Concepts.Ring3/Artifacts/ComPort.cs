using System;
using Concepts.Ring3.Communication.Configuration;
using Concepts.Ring1;
using Concepts.Ring1.SystemX;
using Concepts.Ring3.SystemX;

namespace Concepts.Ring3.Artifacts
{
    /// <summary>
    /// This is a Communication Port
    /// </summary>
    public class ComPort : ComputerSystem
    {
        #region Kind

        public new class Kind : ComputerSystem.Kind { }

        #endregion

    	/// <summary>
    	/// Usually 1 to 256
    	/// </summary>
		public UInt16 Port;

        /// <summary>
        /// Usually 9600
        /// </summary>
        public UInt32 Baud;

        /// <summary>
        /// Usually 9 or 25
        /// </summary>
		public Byte NrPins;

    	/// <summary>
    	/// Usually from 4 to 8
    	/// </summary>
		public Byte DataBits;
    	
    	/// <summary>
    	/// 
    	/// </summary>
    	public ParityConfigurationParameter.ParityOption Parity;
    	
    	/// <summary>
    	/// Usually 1, 1.5 or 2
    	/// </summary>
		public decimal StopBits;
    	
    	/// <summary>
    	/// 
    	/// </summary>
    	public FlowControlConfigurationParameter.FlowControlOption FlowControl;
     
    	/// <summary>
    	/// This function will set ComPort parameters 
    	/// according to values gotten from configuration
    	/// </summary>
    	public void SetValuesFromConfig()
    	{
            Type type = this.GetType();
            PortConfigurationParameter port =
                Kind.GetInstance < PortConfigurationParameter.Kind>().GetParameter(this, type);
            BaudConfigurationParameter baud =
                Kind.GetInstance < BaudConfigurationParameter.Kind>().GetParameter(this, type);
            NumberOfPinsConfigurationParameter pins =
                Kind.GetInstance < NumberOfPinsConfigurationParameter.Kind>().GetParameter(this, type);
            DatabitsConfigurationParameter dbts =
                Kind.GetInstance < DatabitsConfigurationParameter.Kind>().GetParameter(this, type);
            ParityConfigurationParameter prty =
                Kind.GetInstance < ParityConfigurationParameter.Kind>().GetParameter(this, type);
            StopbitsConfigurationParameter sbts =
                Kind.GetInstance < StopbitsConfigurationParameter.Kind>().GetParameter(this, type);
            FlowControlConfigurationParameter fctl =
                Kind.GetInstance < FlowControlConfigurationParameter.Kind>().GetParameter(this, type);
			
    		Port = (ushort)port.LongValue;
			Baud = (uint) baud.LongValue;
			NrPins = (byte) pins.LongValue;
			DataBits = (byte) dbts.LongValue;
			Parity = (ParityConfigurationParameter.ParityOption) ( ( prty == null ) ? ParityConfigurationParameter.ParityOption.None : prty.Value );
			StopBits = sbts.DecimalValue;
			FlowControl = (FlowControlConfigurationParameter.FlowControlOption) ( ( fctl == null ) ? FlowControlConfigurationParameter.FlowControlOption.None : fctl.Value );
    	}
    }
}
