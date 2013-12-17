using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppTest1
{
  class Game
  {
    static void Main(string[] args)
    {
      msg message = new msg();
      pseudowyliczenia wyliczenia = new pseudowyliczenia();
      string anser = "";

      message.wellcome();
      Console.ReadKey();
      Console.Clear();
      
      do
      {
        do
        {
          message.startGame();
          anser = Console.ReadLine();
          anser = anser.ToUpper();
          Console.Clear();
        } while ((anser != "N") && (anser != "K") && (anser != "Z"));

        User gracz = new User();

        if (anser == "N") //NOWA GRA
        {
          string odpowiedz;
          string text;

          Console.WriteLine("Powiedz jak Ci na imię?");
          odpowiedz = Console.ReadLine();
          Console.Clear();
          gracz.newName = odpowiedz;
          Console.Write("Masz na imię ");
          Console.WriteLine(gracz.newName);
          Console.ReadKey();
          Console.Clear();

          do // 1. Pochodzenie
          {
            message.nowaPostac(1);
            odpowiedz = Console.ReadLine();
            Console.Clear();
            text = wyliczenia.nazwyMiejscPochodzenia(odpowiedz);
          } while (text == "ERROR");

          gracz.newPochodzenie = text;
          Console.Write("Pochodzisz z ");
          Console.WriteLine(gracz.newPochodzenie);
          if ((text == "Południowa Hegemonia") || (text == "Texas"))
          {
            gracz.newCechaBudowa += 1;
          }
          else if ((text == "Vegas") || (text == "Detroit"))
          {
            gracz.newCechaZrecznosc += 1;
          }
          else if ((text == "Człowiek Pustyni") || (text == "Miami") || (text == "Missisipi"))
          {
              gracz.newCechaPercepcja += 1;
          }
          else if ((text == "Nowy York") || (text == "Federacja Appalachów"))
          {
              gracz.newCechaCharakter += 1;
          }
          else if ((text == "Posterunek") || (text == "Salt Lake City"))
          {
              gracz.newCechaSpryt += 1;
          }
          else 
          { 
              do
              {
                  message.bonusCechy();
                  odpowiedz = Console.ReadLine();
                  text = wyliczenia.bonusCechy(odpowiedz);
                  Console.Clear();
              }while(text == "ERROR");

              if(text == "B")
              {
                  gracz.newCechaBudowa += 1;
              }
              if (text == "C")
              {
                  gracz.newCechaCharakter += 1;
              }
              if (text == "P")
              {
                  gracz.newCechaPercepcja += 1;
              }
              if (text == "S")
              {
                  gracz.newCechaSpryt += 1;
              }
              if (text == "Z")
              {
                  gracz.newCechaZrecznosc += 1;
              }
          }
          Console.ReadKey();
          Console.Clear();

          do // 2. Profesja
          {
            message.nowaPostac(2);
            odpowiedz = Console.ReadLine();
            Console.Clear();
            text = wyliczenia.nazwyProfesji(odpowiedz);
          } while (text == "ERROR");

          gracz.newProfesjaBohatera = text;
          Console.Write("Twoja profesja to ");
          Console.WriteLine(gracz.newProfesjaBohatera);
          Console.ReadKey();
          Console.Clear();

          do // 3. Cechy
          {
            message.nowaPostac(3);
            odpowiedz = Console.ReadLine();
            Console.Clear();
          } while ((odpowiedz != "1") && (odpowiedz != "2"));

          if (odpowiedz == "1") //Losowanie wartości cech
          {
            Random los = new Random();
            double srednia = 0;
            double suma = 0;
            double czesci = 0;
            int calosc = 0;
            int[] wyniki = {0, 0, 0, 0, 0, 0};

            for (int i = 0; i < 6; i++)
            {
              suma = 0;
              czesci = (los.Next(20) + 1);
              suma += czesci;
              czesci = (los.Next(20) + 1);
              suma += czesci;
              czesci = (los.Next(20) + 1);
              suma += czesci;
              srednia = suma / 3;
              calosc = (int)srednia;
              if (calosc < srednia)
              {
                calosc++;
              }
              if ((calosc < 7) || (calosc > 19))
              {
                if (calosc < 7)
                {
                  wyniki[i] = 6;
                }
                else
                {
                  wyniki[i] = 19;
                }
              }
              else
              {
                wyniki[i] = calosc;
              }
            }

            Array.Sort(wyniki);
            Console.WriteLine("Wyniki: ");
            Console.Write(wyniki[0]);
            Console.Write("  ");
            Console.Write(wyniki[1]);
            Console.Write("  ");
            Console.Write(wyniki[2]);
            Console.Write("  ");
            Console.Write(wyniki[3]);
            Console.Write("  ");
            Console.Write(wyniki[4]);
            Console.Write("  ");
            Console.WriteLine(wyniki[5]);
            do
            {
              calosc = 0;
              Console.WriteLine("");
              Console.WriteLine("Punkty na zręczność");
              text = Console.ReadLine();
              calosc = wyliczenia.przedzial(text);
              if(calosc != 0)
              {
                  int i = 0;
                  bool b = false;

                  do
                  {
                      calosc = wyliczenia.przedzial(text);
                      if (calosc == wyniki[i])
                      {
                          b = true;
                          gracz.newCechaZrecznosc += wyniki[i];
                          wyniki[i] = 0;
                      }
                      else 
                      {
                          i++;
                          calosc = 0;
                      }
                  }while( (b == false) && (i < 6));
              }
            } while(calosc == 0);

            do
            {
                calosc = 0;
                Console.WriteLine("");
                Console.WriteLine("Punkty na percepcja");
                text = Console.ReadLine();
                calosc = wyliczenia.przedzial(text);
                if (calosc != 0)
                {
                    int i = 0;
                    bool b = false;

                    do
                    {
                        calosc = wyliczenia.przedzial(text);
                        if (calosc == wyniki[i])
                        {
                            b = true;
                            gracz.newCechaPercepcja += wyniki[i];
                            wyniki[i] = 0;
                        }
                        else
                        {
                            i++;
                            calosc = 0;
                        }
                    } while ((b == false) && (i < 6));
                }
            } while (calosc == 0);

            do
            {
                calosc = 0;
                Console.WriteLine("");
                Console.WriteLine("Punkty na charakter");
                text = Console.ReadLine();
                calosc = wyliczenia.przedzial(text);
                if (calosc != 0)
                {
                    int i = 0;
                    bool b = false;

                    do
                    {
                        calosc = wyliczenia.przedzial(text);
                        if (calosc == wyniki[i])
                        {
                            b = true;
                            gracz.newCechaCharakter += wyniki[i];
                            wyniki[i] = 0;
                        }
                        else
                        {
                            i++;
                            calosc = 0;
                        }
                    } while ((b == false) && (i < 6));
                }
            } while (calosc == 0);

            do
            {
                calosc = 0;
                Console.WriteLine("");
                Console.WriteLine("Punkty na spryt");
                text = Console.ReadLine();
                calosc = wyliczenia.przedzial(text);
                if (calosc != 0)
                {
                    int i = 0;
                    bool b = false;

                    do
                    {
                        calosc = wyliczenia.przedzial(text);
                        if (calosc == wyniki[i])
                        {
                            b = true;
                            gracz.newCechaSpryt += wyniki[i];
                            wyniki[i] = 0;
                        }
                        else
                        {
                            i++;
                            calosc = 0;
                        }
                    } while ((b == false) && (i < 6));
                }
            } while (calosc == 0);

            do
            {
                calosc = 0;
                Console.WriteLine("");
                Console.WriteLine("Punkty na budowa");
                text = Console.ReadLine();
                calosc = wyliczenia.przedzial(text);
                if (calosc != 0)
                {
                    int i = 0;
                    bool b = false;

                    do
                    {
                        calosc = wyliczenia.przedzial(text);
                        if (calosc == wyniki[i])
                        {
                            b = true;
                            gracz.newCechaBudowa += wyniki[i];
                            wyniki[i] = 0;
                        }
                        else
                        {
                            i++;
                            calosc = 0;
                        }
                    } while ((b == false) && (i < 6));
                }
            } while (calosc == 0);

            Console.ReadKey();
            Console.Clear();
          }

          if (odpowiedz == "2") //przydział użytkownika
          {
            bool kasa = true;
            int wyplata = 100;
 
            do
            {
              int last = 60;
              
              if (kasa == false)
              {
                Console.WriteLine("Pozostało Ci za mało gambli");
                Console.WriteLine("Musisz przydzielić punkty jeszcze raz");
                kasa = true;
                wyplata = 100;
                Console.ReadKey();
                Console.Clear();
              }

              do
              {
                Console.Write("Masz do przydziału ");
                Console.WriteLine(last);
                Console.WriteLine("Ile punktów chcesz przeznaczyć na zręczność?");
                text = Console.ReadLine();
                Console.Clear();
              } while (wyliczenia.przedzial(text) == 0);

              last = last - wyliczenia.przedzial(text);
              gracz.newCechaZrecznosc += wyliczenia.przedzial(text);

              do
              {
                Console.Write("Masz do przydziału ");
                Console.WriteLine(last);
                Console.WriteLine("Ile punktów chcesz przeznaczyć na percepcię?");
                text = Console.ReadLine();
                Console.Clear();
              } while (wyliczenia.przedzial(text) == 0);

              last = last - wyliczenia.przedzial(text);
              gracz.newCechaPercepcja += wyliczenia.przedzial(text);
              
              do
              {
                Console.Write("Masz do przydziału ");
                Console.WriteLine(last);
                Console.WriteLine("Ile punktów chcesz przeznaczyć na Charakter?");
                text = Console.ReadLine();
                Console.Clear();
              } while (wyliczenia.przedzial(text) == 0);

              last = last - wyliczenia.przedzial(text);
              gracz.newCechaCharakter += wyliczenia.przedzial(text);

              do
              {
                Console.Write("Masz do przydziału ");
                Console.WriteLine(last);
                Console.WriteLine("Ile punktów chcesz przeznaczyć na spryt?");
                text = Console.ReadLine();
                Console.Clear();
              } while (wyliczenia.przedzial(text) == 0);

              last = last - wyliczenia.przedzial(text);
              gracz.newCechaSpryt += wyliczenia.przedzial(text);

              do
              {
                Console.Write("Masz do przydziału ");
                Console.WriteLine(last);
                Console.WriteLine("Ile punktów chcesz przeznaczyć na budowę?");
                text = Console.ReadLine();
                Console.Clear();
              } while (wyliczenia.przedzial(text) == 0);

              last = last - wyliczenia.przedzial(text);
              gracz.newCechaBudowa += wyliczenia.przedzial(text);

              if (last < 0)
              {
                wyplata += (last * 10);
              }
              else
              {
                wyplata += (last * 30);
              }

              gracz.newGambleUser = wyplata;

              if (wyplata <= 30)
              {
                  kasa = false;
              }
            }while(wyplata<=30);
          }
            
          do // 4. Specjalizacje
          {
              message.nowaPostac(4);
              odpowiedz = Console.ReadLine();
              Console.Clear();
              text = wyliczenia.nazwySpecjalizacji(odpowiedz);
          } while (text == "ERROR");

          gracz.newSpecjalizacjaBohatera = text;
          Console.Write("Twoja specjalizacja to ");
          Console.WriteLine(gracz.newSpecjalizacjaBohatera);
          Console.ReadKey();
          Console.Clear();
            
          // 5. Umiejętności
          message.nowaPostac(5);
          message.spisUmiejetnosci(gracz.newSpecjalizacjaBohatera);
          Console.ReadKey();
          Console.Clear();
            
          Console.WriteLine("Karta postaci");
          Console.Write("Twoje imię: ");
          Console.WriteLine(gracz.newName);
          Console.Write("Pochodzenie: ");
          Console.WriteLine(gracz.newPochodzenie);
          Console.Write("Profesja: ");
          Console.WriteLine(gracz.newProfesjaBohatera);
          Console.Write("Specjalizacja: ");
          Console.WriteLine(gracz.newSpecjalizacjaBohatera);
          Console.Write("Zręczność: ");
          Console.WriteLine(gracz.newCechaZrecznosc);
          Console.Write("Percepcja: ");
          Console.WriteLine(gracz.newCechaPercepcja);
          Console.Write("Charakter: ");
          Console.WriteLine(gracz.newCechaCharakter);
          Console.Write("Spryt: ");
          Console.WriteLine(gracz.newCechaSpryt);
          Console.Write("Budowa: ");
          Console.WriteLine(gracz.newCechaBudowa);
          Console.Write("Kasa: ");
          Console.WriteLine(gracz.newGambleUser);
          /*Console.ReadKey();
          Console.Clear();
          gracz.setUmiejetnosci(12, 0, 0, 0);
          Console.WriteLine(gracz.getUmiejetnosci(0, 0, 0));
          Console.WriteLine();
          Console.WriteLine();
          Console.WriteLine();
          Console.WriteLine();
          Console.WriteLine();*/
        }//Koniec tworzenia nowej postaci

        if (anser == "K")
        {
          //Kod wczytywania postępów w grze
        }

        if ((anser == "K") || (anser == "N"))
        { 
          //Gra
        }
      
      } while(anser == "Z");

      message.byebye();
      Console.ReadKey();
      Console.Clear();
    }

    /*static int kx()
    {
      int liczba = 20;
      Random wynik = new Random();
      int los = (wynik.Next(liczba) + 1);
      return los;
    }*/
  }
}
