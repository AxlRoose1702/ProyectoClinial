﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCLINICAL.Utilities.Constants
{
    public class StoreProcedures
    {
        #region uspAnalysis
        public const string uspAnalysisList = "uspAnalysisList";
        public const string uspAnalysisById = "uspAnalysisById";
        public const string uspAnalysisRegister = "uspAnalysisRegister";
        public const string uspAnalysisEdit = "uspAnalysisEdit";
        public const string uspAnalysisRemove = "uspAnalysisRemove";
        public const string uspAnalysisChangeState = "uspAnalysisChangeState";
        #endregion

        #region uspExams
        public const string uspExamList = "uspExamList";
        public const string uspExamById = "uspExamById";
        public const string uspExamRegister = "uspExamRegister";
        public const string uspExamEdit = "uspExamEdit";
        public const string uspExamRemove = "uspExamRemove";
        public const string uspExamChangeState = "uspExamChangeState";
        #endregion

        #region uspPatients
        public const string uspPatientList = "uspPatientList";
        public const string uspPatientById = "uspPatientById";
        public const string uspPatientRegister = "uspPatientRegister";
        public const string uspPatientEdit = "uspPatientEdit";
        public const string uspPatientRemove = "uspPatientRemove";
        public const string uspPatientChangeState = "uspPatientChangeState";
        #endregion

        #region uspMedics
        public const string uspMedicList = "uspMedicList";
        public const string uspMedicById = "uspMedicById";
        public const string uspMedicRegister = "uspMedicRegister";
        public const string uspMedicEdit = "uspMedicEdit";
        public const string uspMedicRemove = "uspMedicRemove";
        public const string uspMedicChangeState = "uspMedicChangeState";
        #endregion

        #region uspTakeExams
        public const string uspTakeExamList = "uspTakeExamList";
        #endregion

    }

    public class TB
    {
        public const string Analysis = "Analysis";
        public const string Exams = "Exams";
        public const string Medics = "Medics";
        public const string Patients = "Patients";
        public const string TakeExam = "TakeExam";

    }

    /*
     order by ex.ExamId
	 offset (@PageNumber -1) * @PageSize rows
	 fetch next @PageSize Rows only
     */
}