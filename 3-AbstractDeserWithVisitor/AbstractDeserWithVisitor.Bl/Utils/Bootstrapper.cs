﻿using AbstractDeserWithVisitor.Bl.JsonConverters;
using AbstractDeserWithVisitor.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AbstractDeserWithVisitor.Bl.Utils
{
    public static class Bootstrapper
    {
        public static AbstractOperation BuildPipelineFromJson(string jsonMetadata)
        {
            return JsonConvert.DeserializeObject<AbstractOperation>(jsonMetadata, new PipelineConverter());
        }


        public static AbstractOperation BuildPipelineFromXml(string xmlData)
        {
            throw new NotImplementedException();
        }
    }
}
