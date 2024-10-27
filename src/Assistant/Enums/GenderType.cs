namespace Assistant.Enums;

/// <summary>
///     Gender of the patient
/// </summary>
public enum GenderType
{
    /// <summary>
    ///     TR: Erkek
    /// </summary>
    Male = 1,

    /// <summary>
    ///     TR: Kadin
    /// </summary>
    Female = 2,

    /// <summary>
    ///     TR: Her iki cinsiyet veya belirtilmemis
    /// </summary>
    BothGendersOrUnspecified = 3,

    /// <summary>
    ///     TR: Bilinmiyor
    /// </summary>
    Unknown = 9
}