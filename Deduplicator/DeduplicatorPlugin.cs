﻿using System.ComponentModel.Composition;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace DynCrmExp.Deduplicator
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Deduplicator"),
        ExportMetadata("Description", "Data Duplicate Detection Tool"),
        ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAUkSURBVFhH7ZZrbFRFFMfPzH3s3t1l21raspS2QHnVtkCtgIR+UFKDDyIxGvpBiihqE/1ArBo1aQLKw8RAjJ8EjMGYQuMXBcQQNNLUAilQEKvUtkhtxW6ppdAH+7iPueO5tzcbug9A+GTkl9zMOWdmZ/5z55y5C/f430OcNoHd80qIlp4mOm5SNJOZtadamOPeEUkF/DBjTpFM6TuyJJWgm1IkwrmuR1XOWchkgyIhPSKQth5da9o+ePlSuxq9pbiEyTdkZpNV/vQ9HkrXokuAEIbPGD7jA24C55wSDjJaZoixlh5N3bq+r/eo052UhFk350xNf9Tnb0azBBfVwx7vh8eo+OXPgYWZOpVc46MS4cAJMEZkNURnZ0wSK2UtB3q6FjFNb15x9sQXzrAEEgTsyi2Yv8CtWAL8TJbbO+YvqHh7Zs1L1zT6Lgdwj4+6JVykwCQw//aJpM1HowcyosFDrTuqh5z+GNRpY0yX5DJs/JZN3O4zW9SpUsQU1jEOGSYH5TYfj8ZgUojRwgGVPH0xonx+jhR2Qs3BOli0ZkJiTxBQ4laoRMhix4VhXT/pKl4+LWrwfCd0xxgmZIJ38vtQUbPLCdlMEFDqVmSZEOsN4PZpVAzk/tQfgnLcvc+O3T2Y1MI6WLfvecefKKA6/b4pAiH3WzYXhODRPy72Sh7/IrszCQS4KnD2Oz5dXiPSlxMe4pKpO70poZA+7Q2YW4nVEicAM7IMH49lGy75t9Da14evq8b4G0mEudXQprSO75ZMad1bWvvNhpUNjXXh+qb3jMWs/yucJ/UdQMVCWFaTY5t2wMFLBev8JduRpFONal7ApOIc24+DcrPf7D3ZcPXw5qt9zTu1h0HL9Riqp2A0KG5s3NaUo/B6Z2gyROCGnVcxAXXZAUHj5gO2g/U/DOTMQBjKdMbtNxKPoEcvZI4Gg5b9dUGhG5N3NZp2WRNDF/VI6JBlp4CIgqBYRkyAi5AcHxXs3TIqjBpT89oiVFmCtZ/0e0A5OxX88RO9Pm9Gmp8KtZi8VXYHinf5fJ2pfufADE5HLCMmYKnHV4hNrmWbBNq3910ZFkSx3PLjIXj3l/efGzxYMKsqX5LrvZRuwrB1S3Li8zUfE4TT1O1N+lsbk1mL91pmTABepUuwsc8/KoitoYrqjDBeJJYfD2Y8ffPCwa3ZoliPO1+JIQl3bjCXq0kuLqrd90hd3phOnx0fnQTOjkPjR9cs0xbwkMcrYgI+aNkI5y75ZDRz9mys/4ATm0C2OmJkUSOkETKkC7SLe5T90azJr/66bPlzVbNezupVPTtVxqc7w+OJgK7uhe7jdr3aSbMxOzCp0uc/jYk0F+t/eLR0fsXq/BeeGiG+bVZ/PBKF6OP58gY6OvDLpaEx8pfuVlTBNUt3+R9TTVppmDzVxcWBaQ3Q8f0rcGRryArYAjCLywKidBxNxVSUtj2Ca3nDih27rhvkGas/FZSAyTmmhDPPLcBTNk9AZGQN7Hyyx4mNH0HQMKLY4DwAYcNo7V1VyzTGF1r+zcCPDr3NxQ082MMQGlp/4+IWtoAtA8GObk1div9snqCy/PHZq1KRAdSuiLvExF1fBkP9AHpa1sLuVZ1OPEZS9fO2nX6x84r+Ke4uViX/kgiWWjcufgSuD34GLXs64fy3Sa/mpAL8r+0vHhPTD6CZ9Ba8ERSp4TQR/HoOgqn/iRl+HvTwMbjS3Q7730r4AxJP6vObWeEioiQ43k1BEdbLYkCpjhmO9j3u8Z8B4B/n0QcNzT1AfAAAAABJRU5ErkJggg=="),
        ExportMetadata("BigImageBase64", "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"),
        ExportMetadata("BackgroundColor", "Lavender"),
        ExportMetadata("PrimaryFontColor", "Black"),
        ExportMetadata("SecondaryFontColor", "Gray")]
    public class DeduplicatorPlugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new DeduplicatorPluginControl();
        }
    }
}