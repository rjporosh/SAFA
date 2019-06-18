using AutoMapper;
using SAFA.Models;
using SAFA.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SAFA
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Mapper.Initialize(configaration =>
            {

                // For ReligiousFundType

                configaration.CreateMap<ReligiousFundType, ReligiousFundVM>();
                configaration.CreateMap<ReligiousFundVM, ReligiousFundType>();

                // For Religion

                configaration.CreateMap<Religion, ReligionVM>();
                configaration.CreateMap<ReligionVM, Religion>();
                // For Invert

                configaration.CreateMap<InvertType, InvertVM>();
                configaration.CreateMap<InvertVM, InvertType>();
                // For Charitable

                configaration.CreateMap<CharitableFundType, CharitableVM>();
                configaration.CreateMap<CharitableVM, CharitableFundType>();
                // For Id

                configaration.CreateMap<IdProofType, IdVM>();
                configaration.CreateMap<IdVM, IdProofType>();
                // For PaymentType

                configaration.CreateMap<PaymentType, PaymentTypeVM>();
                configaration.CreateMap<PaymentTypeVM, PaymentType>();
            });
        }
    }
}
