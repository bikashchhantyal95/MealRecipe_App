using System;
using System.Globalization;
using CommunityToolkit.Maui.Converters;

namespace MovieRecipeMobileAPp.Converters

{
	public class StringToColorConvertor: BaseConverterOneWay<string, Color>
	{
		public StringToColorConvertor()
		{
		}

        public override Color DefaultConvertReturnValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override Color ConvertFrom(string value, CultureInfo culture) => Color.FromHex(value);

    }
}

