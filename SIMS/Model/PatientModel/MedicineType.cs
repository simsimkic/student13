/***********************************************************************
 * Module:  MedicineType.cs
 * Purpose: Definition of the Class MedicineType
 ***********************************************************************/

using System;

namespace SIMS.Model.PatientModel
{
    public enum MedicineType
    {
        PILL,
        IV,
        LIQUID,
        TABLET,
        TOPICAL_MEDICINE,
        DROPS,
        SUPPOSITORIES,
        INHALERS,
        INJECTIONS
    }
}