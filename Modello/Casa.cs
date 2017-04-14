using System;
using Scacchi.Modello.Pezzi;

namespace Scacchi.Modello
{
    public class Casa : ICasa
    {
        private Colonna colonna;
        private Traversa traversa;
        private IPezzo pezzoPresente;
        public Casa(Colonna colonna, Traversa traversa){
            this.colonna=colonna;
            this.traversa=traversa;
        }


        public Colonna Colonna {
            get{return colonna;}
        }

        public Traversa Traversa {
            get{return traversa;}
        }

        public IPezzo PezzoPresente {
            get {
                return pezzoPresente;
            }
            set {
                pezzoPresente = value;
            }
        }
    }
}
