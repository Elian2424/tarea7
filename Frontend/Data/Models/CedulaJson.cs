using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prueba.Data.Models
{
    public class CedulaJson
    {
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string LugarNacimiento { get; set; }
        public int IDCategoria { get; set; }
        public string IdSexo { get; set; }
        public string IdEstadoCivil { get; set; }
        public int IdOcupacion { get; set; }
        public int IDNacionalidad { get; set; }
        public int IDMunicipio { get; set; }
        public int IDColegio { get; set; }
        public object IDCausaCancelacion { get; set; }
        public string IDEstatus { get; set; }
        public string EstatusCedulaAzul { get; set; }
        public string CedulaAnterior { get; set; }
        public string mun_ced { get; set; }
        public string seq_ced { get; set; }
        public string ver_ced { get; set; }
        public int V2004 { get; set; }
        public int V2008 { get; set; }
        public int V2012 { get; set; }
        public int V2016 { get; set; }
        public int PLD { get; set; }
        public int PRD { get; set; }
        public int PRSC { get; set; }
        public int PRM { get; set; }
        public object Multiplicador_NombreCompleto { get; set; }
        public object Multiplicador_Cedula { get; set; }
        public object Simpatia_Descripcion { get; set; }
        public object Ilocalizable { get; set; }
        public object Apodo { get; set; }
        public object PadronLF { get; set; }
        public bool ok { get; set; }
        public string foto { get; set; }
    }
}
