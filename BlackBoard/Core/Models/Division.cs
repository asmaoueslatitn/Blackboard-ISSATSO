using System.ComponentModel;

namespace BlackBoard.Core.Models
{
    public enum Division
    {
        [Description("Master")]
        Master = 1,

        [Description("License")]
        License=2,

        [Description("Engineering")]
        Engineering = 3,

        [Description("Preparatory ")]
        Preparatory =4
    }
}