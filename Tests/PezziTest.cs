using System;
using System.Linq;
using Scacchi.Modello.Pezzi;
using Xunit;

namespace Scacchi.Modello
{
    public class PezziTest
    {
/*--------------------------------------PEDONE------------------------------------------ */
        [Fact]
        public void IlPedoneBiancoPuoMuovereAvantiDiUnaCasa()
        {
            //Given
            Pedone pedone = new Pedone(Colore.Bianco);
            //When
            bool esito = pedone.PuòMuovere(
                    colonnaPartenza: Colonna.A,
                    traversaPartenza: Traversa.Seconda,
                    colonnaArrivo: Colonna.A,
                    traversaArrivo: Traversa.Terza);

            //Then
            Assert.True(esito);
        }

        [Theory]
        [InlineData(typeof(Donna))]
        [InlineData(typeof(Pedone))]
        public void IlPedoneNonPuòRestareFermo(Type t) {
            //Given
            IPezzo pezzo = Activator.CreateInstance(t, Colore.Bianco) as IPezzo;
            //When
            bool esito = pezzo.PuòMuovere(Colonna.A, Traversa.Prima, Colonna.A, Traversa.Prima);
            //Then
            Assert.True(esito, t.Name);
        }
        [Fact]
        public void IlPedoneBiancoNonPuoMuovereIndietroDiUnaCasa(){
            //Given
            Pedone pedone = new Pedone(Colore.Bianco);
            //When
            bool esito = pedone.PuòMuovere(
                colonnaPartenza: Colonna.A,
                traversaPartenza: Traversa.Settima,
                colonnaArrivo: Colonna.A,
                traversaArrivo: Traversa.Sesta);
            //Then
            Assert.False(esito);
        }

        [Fact]
        public void IlPedoneNeroNonPuoMuovereIndietroDiUnaCasa(){
            //Given
            Pedone pedone = new Pedone(Colore.Nero);
            //When
            bool esito = pedone.PuòMuovere(
                colonnaPartenza: Colonna.A,
                traversaPartenza: Traversa.Terza,
                colonnaArrivo: Colonna.A,
                traversaArrivo: Traversa.Quarta);
            //Then
            Assert.False(esito);
        }

        [Fact]
        public void IlPedoneBiancoPuoMuovereAvantiDiDueCaseDallaSecondaTravers(){
            //Given
            Pedone pedone = new Pedone(Colore.Bianco);
            //When
            bool esito = pedone.PuòMuovere(
                colonnaPartenza: Colonna.A,
                traversaPartenza: Traversa.Seconda,
                colonnaArrivo: Colonna.A,
                traversaArrivo: Traversa.Quarta);
            //Then
            Assert.True(esito);
        }

        [Fact]
        public void IlPedoneNeroPuoMuovereAvantiDiDueCaseDallaSettimaTravers(){
            //Given
            Pedone pedone = new Pedone(Colore.Nero);
            //When
            bool esito = pedone.PuòMuovere(
                colonnaPartenza: Colonna.A,
                traversaPartenza: Traversa.Settima,
                colonnaArrivo: Colonna.A,
                traversaArrivo: Traversa.Quinta);
            //Then
            Assert.True(esito);
        }

        [Fact]
        public void IlPedoneNonPuòRimanereSullaStessaCasa(){
            //Given
            Pedone pedone = new Pedone(Colore.Nero);
            //When
            bool esito = pedone.PuòMuovere(
                colonnaPartenza: Colonna.A,
                traversaPartenza: Traversa.Settima,
                colonnaArrivo: Colonna.A,
                traversaArrivo: Traversa.Settima);
            //Then
            Assert.False(esito);
        }

/*--------------------------------------------TORRE--------------------------------------- */
        [Fact]
        public void LaTorrePuoMuovereInVerticale(){
            //Given
            Torre torre = new Torre(Colore.Nero);
            //When
            bool esito = torre.PuòMuovere(
                colonnaPartenza: Colonna.A,
                traversaPartenza: Traversa.Prima,
                colonnaArrivo: Colonna.A,
                traversaArrivo: Traversa.Sesta);
            //Then
            Assert.True(esito);

        }
        [Fact]
        public void LaTorrePuoMuovereInOrizzontale(){
            //Given
            Torre torre = new Torre(Colore.Nero);
            //When
            bool esito = torre.PuòMuovere(
                colonnaPartenza: Colonna.A,
                traversaPartenza: Traversa.Prima,
                colonnaArrivo: Colonna.F,
                traversaArrivo: Traversa.Prima);
            //Then
            Assert.True(esito);
        }
        [Fact]
        public void LaTorreNonPuoMuovereInDiagonale(){
            //Given
            Torre torre = new Torre(Colore.Bianco);
            //When
            bool esito = torre.PuòMuovere(
                colonnaPartenza: Colonna.A,
                traversaPartenza: Traversa.Prima,
                colonnaArrivo: Colonna.F,
                traversaArrivo: Traversa.Quarta);
            //Then
            Assert.False(esito);
        }
/*--------------------------------------ALFIERE------------------------------- */
        [Fact]
        public void LAlfierePuoMuovereInDiagonale(){
                //Given
                Alfiere alfiere = new Alfiere(Colore.Bianco);
                //When
                bool esito = alfiere.PuòMuovere(
                    colonnaPartenza: Colonna.A,
                    traversaPartenza: Traversa.Prima,
                    colonnaArrivo: Colonna.F,
                    traversaArrivo: Traversa.Sesta);
                //Then
                Assert.True(esito);
        }

        [Fact]
        public void LAlfierePuoMuovereSoloInDiagonale(){
                //Given
                Alfiere alfiere = new Alfiere(Colore.Nero);
                //When
                bool esito = alfiere.PuòMuovere(
                    colonnaPartenza: Colonna.F,
                    traversaPartenza: Traversa.Ottava,
                    colonnaArrivo: Colonna.C,
                    traversaArrivo: Traversa.Quarta);
                //Then
                Assert.False(esito);
        }

/*--------------------------------CAVALLO---------------------------------------- */

[Fact]
        public void IlCavalloPuoMuovereAdL(){
                //Given
                Cavallo cavallo = new Cavallo(Colore.Bianco);
                //When
                bool esito = cavallo.PuòMuovere(
                    colonnaPartenza: Colonna.B,
                    traversaPartenza: Traversa.Prima,
                    colonnaArrivo: Colonna.A,
                    traversaArrivo: Traversa.Terza);
                //Then
                Assert.True(esito);
        }

        [Fact]
        public void IlCavalloPuoMuovereSoloAdL(){
                //Given
                Cavallo cavallo = new Cavallo(Colore.Nero);
                //When
                bool esito = cavallo.PuòMuovere(
                    colonnaPartenza: Colonna.G,
                    traversaPartenza: Traversa.Ottava,
                    colonnaArrivo: Colonna.E,
                    traversaArrivo: Traversa.Sesta);
                //Then
                Assert.False(esito);
        }
/*------------------------------------Donna-------------------------------------- */
[Fact]
        public void LaDonnaPuoMuovereInVerticale(){
            //Given
            Donna donna = new Donna(Colore.Nero);
            //When
            bool esito = donna.PuòMuovere(
                colonnaPartenza: Colonna.A,
                traversaPartenza: Traversa.Prima,
                colonnaArrivo: Colonna.A,
                traversaArrivo: Traversa.Sesta);
            //Then
            Assert.True(esito);

        }
        [Fact]
        public void LaDonnaPuoMuovereInOrizzontale(){
            //Given
            Donna donna = new Donna(Colore.Nero);
            //When
            bool esito = donna.PuòMuovere(
                colonnaPartenza: Colonna.A,
                traversaPartenza: Traversa.Prima,
                colonnaArrivo: Colonna.F,
                traversaArrivo: Traversa.Prima);
            //Then
            Assert.True(esito);
        }

        [Fact]
        public void LaDonnaPuoMuovereInDiagonale(){
                //Given
            Donna donna = new Donna(Colore.Nero);
            //When
            bool esito = donna.PuòMuovere(
                    colonnaPartenza: Colonna.A,
                    traversaPartenza: Traversa.Prima,
                    colonnaArrivo: Colonna.F,
                    traversaArrivo: Traversa.Sesta);
                //Then
                Assert.True(esito);
        }

        [Fact]
        public void LaDonnaPuoMuovereSoloInDiagonaleOrizzontaleEVerticale(){
                //Given
                Donna donna = new Donna(Colore.Nero);
                //When
                bool esito = donna.PuòMuovere(
                    colonnaPartenza: Colonna.F,
                    traversaPartenza: Traversa.Ottava,
                    colonnaArrivo: Colonna.C,
                    traversaArrivo: Traversa.Quarta);
                //Then
                Assert.False(esito);
        }

/*-----------------------------------------RE--------------------------------------------- */
[Fact]
        public void IlRePuoMuovereInVerticaleDiUno(){
            //Given
            Re re = new Re(Colore.Nero);
            //When
            bool esito = re.PuòMuovere(
                colonnaPartenza: Colonna.A,
                traversaPartenza: Traversa.Prima,
                colonnaArrivo: Colonna.A,
                traversaArrivo: Traversa.Seconda);
            //Then
            Assert.True(esito);

        }
        [Fact]
        public void IlRePuoMuovereInOrizzontaleDiUno(){
            //Given
            Re re = new Re(Colore.Nero);
            //When
            bool esito = re.PuòMuovere(
                colonnaPartenza: Colonna.A,
                traversaPartenza: Traversa.Prima,
                colonnaArrivo: Colonna.B,
                traversaArrivo: Traversa.Prima);
            //Then
            Assert.True(esito);
        }

        [Fact]
        public void IlRePuoMuovereInDiagonaleDiUno(){
            //Given
            Re re = new Re(Colore.Nero);
            //When
            bool esito = re.PuòMuovere(
                    colonnaPartenza: Colonna.A,
                    traversaPartenza: Traversa.Prima,
                    colonnaArrivo: Colonna.B,
                    traversaArrivo: Traversa.Seconda);
                //Then
                Assert.True(esito);
        }

        [Fact]
        public void IlRePuoMuovereSoloDiUno(){
            //Given
            Re re = new Re(Colore.Nero);
            //When
            bool esito = re.PuòMuovere(
                    colonnaPartenza: Colonna.F,
                    traversaPartenza: Traversa.Ottava,
                    colonnaArrivo: Colonna.C,
                    traversaArrivo: Traversa.Quarta);
                //Then
                Assert.False(esito);
        }

    }
}