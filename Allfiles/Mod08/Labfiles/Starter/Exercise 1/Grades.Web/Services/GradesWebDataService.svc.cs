﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using System.Data.Services.Common;
using System.Data.Services;
using Grades.DataModel;

namespace Grades.Web.Services
{
    //TODO: Excersice 1: Task 2a: Replace the object keyword with your data source class name.
    public class GradesWebDataService : DataService<SchoolGradesDBEntities>
    {
        public static void InitializeService(DataServiceConfiguration config)
        {
            //TODO: Excersice 1: Task 2b: set rules to indicate which entity sets and service operations are visible, updatable, etc
            config.SetEntitySetAccessRule("Grades", EntitySetRights.All);
            config.SetEntitySetAccessRule("Teachers", EntitySetRights.All);
            config.SetEntitySetAccessRule("Students", EntitySetRights.All);
            config.SetEntitySetAccessRule("Subjects", EntitySetRights.All);
            config.SetEntitySetAccessRule("Users", EntitySetRights.All);

            config.SetServiceOperationAccessRule("StudentsInClass", ServiceOperationRights.AllRead);//read only, this is a GET

        }

        [WebGet]
        public IEnumerable<Student> StudentsInClass(string className)
        {
            var res = from Student s in this.CurrentDataSource.Students
                    where String.Equals(s.Teacher.Class, className)
                    select s;
            return res;
        }

    }


}
