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

        [Fact]
        public void IlPedoneNeroPuoMuovereAvantiDiUnaCasa()
        {
            //Given
            Pedone pedone = new Pedone(Colore.Nero);
            //When
            bool esito = pedone.PuòMuovere(
                colonnaPartenza: Colonna.A,
                traversaPartenza: Traversa.Settima,
                colonnaArrivo: Colonna.A,
                traversaArrivo: Traversa.Sesta);

            //Then
            Assert.True(esito);
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
        public void IlCavalloBiancoPuoMuovereSoloAdL(){
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
/*------------------------------------Regina-------------------------------------- */
[Fact]
        public void LaReginaPuoMuovereInVerticale(){
            //Given
            Regina regina = new Regina(Colore.Nero);
            //When
            bool esito = regina.PuòMuovere(
                colonnaPartenza: Colonna.A,
                traversaPartenza: Traversa.Prima,
                colonnaArrivo: Colonna.A,
                traversaArrivo: Traversa.Sesta);
            //Then
            Assert.True(esito);

        }
        [Fact]
        public void LaReginaPuoMuovereInOrizzontale(){
            //Given
            Regina regina = new Regina(Colore.Nero);
            //When
            bool esito = regina.PuòMuovere(
                colonnaPartenza: Colonna.A,
                traversaPartenza: Traversa.Prima,
                colonnaArrivo: Colonna.F,
                traversaArrivo: Traversa.Prima);
            //Then
            Assert.True(esito);
        }

        [Fact]
        public void LaReginaPuoMuovereInDiagonale(){
                //Given
            Regina regina = new Regina(Colore.Nero);
            //When
            bool esito = regina.PuòMuovere(
                    colonnaPartenza: Colonna.A,
                    traversaPartenza: Traversa.Prima,
                    colonnaArrivo: Colonna.F,
                    traversaArrivo: Traversa.Sesta);
                //Then
                Assert.True(esito);
        }

        [Fact]
        public void LaReginaPuoMuovereSoloInDiagonaleOrizzontaleEVertical(){
                //Given
                Regina regina = new Regina(Colore.Nero);
                //When
                bool esito = regina.PuòMuovere(
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