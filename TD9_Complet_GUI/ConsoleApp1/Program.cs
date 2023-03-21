using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsilvGui;

namespace ConsoleApp1
{
    class Program
    {//*

        static int ConnexionLigne(int[,] matrice,int ligne)               //Connecte les bords de la matrice pour former un tore
        {      
                 if (ligne == -1)                                       //si la ligne est inferieur à la première ligne, on considère qu'elle est égale à la dernière
                {
                    ligne = matrice.GetLength(0) - 1;
                }
                if (ligne == -2)                                       //si la ligne est inferieur à la première ligne, on considère qu'elle est égale à la dernière
                {
                    ligne = matrice.GetLength(0) - 2;
                }
                if (ligne == matrice.GetLength(0))                  
                {
                    ligne = 0;
                }
                if (ligne == matrice.GetLength(0) + 1)                 
                {
                    ligne = 1;
                }
            return ligne;
        }

        static int ConnexionColonne(int[,] matrice, int colonne)               //Connecte les bords de la matrice pour former un tore
        {
            if (colonne == -1)                                       //si la colonne est inferieur à la première ligne, on considère qu'elle est égale à la dernière
            {
                colonne = matrice.GetLength(1) - 1;
            }
            if (colonne == -2)                                       //si la colonne est inferieur à la première ligne, on considère qu'elle est égale à la dernière
            {
                colonne = matrice.GetLength(1) - 2;
            }
            if (colonne == matrice.GetLength(1))
            {
                colonne = 0;
            }
            if (colonne == matrice.GetLength(1) + 1)
            {
                colonne = 1;
            }
            return colonne;
        }

        static void Afficher_Matrices(int[,] matrice)       //Permet d'afficher une matrice, pas forcément utile dans le code maisutile pour les vérifications
        {
            if (matrice == null)
            {
                Console.WriteLine("Matrice null");
            }
            else if (matrice.Length == 0)
            {
                Console.WriteLine("Matrice vide");
            }
            else
            {
                int n = 0;
                while (n < matrice.GetLength(0))
                {
                    for (int i = 0; i < matrice.GetLength(1); i++)
                    {
                        if (matrice[n, i] < 10)
                        {
                            Console.Write(matrice[n, i] + "  ");
                        }
                        else
                        {
                            Console.Write(matrice[n, i] + " ");
                        }
                    }
                    Console.WriteLine("");
                    n = n + 1;
                }
            }
            Console.WriteLine("");
        }

        static void Menu()              //1er Menu de choix         
        {
                Console.WriteLine("Choisissez votre mode de jeu");
                Console.WriteLine("Tapez 1 pour le jeu de la vie SANS visualisation des états futur");
                Console.WriteLine("Tapez 2 pour le jeu de la vie AVEC visualisation des états futur");
                Console.WriteLine("Tapez 3 pour le jeu de la vie à DEUX populations SANS visualisation des états futur");
                Console.WriteLine("Tapez 4 pour le jeu de la vie à DEUX populations AVEC visualisation des états futur");
            int valeur = Convert.ToInt32(Console.ReadLine());            

            if(valeur==1)
            {
                Menu1();
            }
            else if (valeur == 2)
            {
                Menu2();
            }
            else if (valeur == 3)
            {
                Menu3();
            }
            else if (valeur == 4)
            {
                Menu4();
            }
        }

        static int[,] Choix_Création()                      //Crée une matrice avec les dimensions que l'utilisateur a rentré
         {
             Console.WriteLine("Choisissez le nombre de ligne du tableau de jeu");
             int ligne = Convert.ToInt32(Console.ReadLine());

             Console.WriteLine("Choisissez le nombre de colonne du tableau de jeu");
             int colonne = Convert.ToInt32(Console.ReadLine());

             int[,] matrice = new int[ligne, colonne];

            return matrice;
         }

        static void Remplissage_Matrice(int[,] matrice)     //permet d'initialiser la grille en début de partie selon un pourcentage défini par l'utilisateur
        {
            Console.WriteLine("Choisissez le taux de remplissage de départ de la grille (en % ; entre 10 et 90)");
            int taux = Convert.ToInt32(Console.ReadLine());

            while(taux>90||taux<10)                     //si le taux n'estpas entre 10% ou 90% on le redemande
            {
                Console.WriteLine("Choisissez un taux de remplissage de départ de la grille valide(en % ; entre 10 et 90)");
                taux = Convert.ToInt32(Console.ReadLine());
            }
                int nbrcellulesagénérer = (matrice.Length * taux) /100;        //nbr de cellules à générer selon le taux

                int position1 = 0;
                int position2 = 0;
                Random aleat = new Random();   //la variable aléatoire
                int n = 0;
                while (n < nbrcellulesagénérer)                 //on génère 2 nombres (cf lignes et colonnes) 
                {
                    position1 = aleat.Next(0, matrice.GetLength(0));        
                    position2 = aleat.Next(0, matrice.GetLength(1));

                    if(matrice[position1,position2]==1)         //si la cellule est déja vivante, on ne la compte pas et on va en générer une de plus
                    {
                        n = n;
                    }
                    else
                    {
                        matrice[position1, position2] = 1;      //si la cellule n'est pas déja vivante, on la compte et on continue
                        n = n + 1;
                    }
                }           
        }

        static void Remplissage_Matrice_2_populations(int[,] matrice)     //permet d'initialiser la grille en début de partie selon un pourcentage défini par l'utilisateur
        {
            Console.WriteLine("Choisissez le taux de remplissage de départ de la grille (en % ; entre 10 et 90)");
            int taux = Convert.ToInt32(Console.ReadLine());

            while (taux > 90 || taux < 10)                     //si le taux n'estpas entre 10% ou 90% on le redemande
            {
                Console.WriteLine("Choisissez un taux de remplissage de départ de la grille valide(en % ; entre 10 et 90)");
                taux = Convert.ToInt32(Console.ReadLine());
            }
            int nbrcellulesagénérer = (matrice.Length * taux) / 100;        //nbr de cellules à générer selon le taux

            int position1 = 0;
            int position2 = 0;
            Random aleat = new Random();   //la variable aléatoire
            int n = 0;
            while (n < nbrcellulesagénérer / 2)                 //on génère 2 nombres (cf lignes et colonnes) 
            {
                position1 = aleat.Next(0, matrice.GetLength(0));
                position2 = aleat.Next(0, matrice.GetLength(1));

                if (matrice[position1, position2] == 1)         //si la cellule est déja vivante, on ne la compte pas et on va en générer une de plus
                {
                    n = n;
                }
                else
                {
                    matrice[position1, position2] = 1;      //si la cellule n'est pas déja vivante, on la compte et on continue
                    n = n + 1;
                }
            }
            n = 0;
            while (n < nbrcellulesagénérer / 2)                 //on génère 2 nombres (cf lignes et colonnes) 
            {
                position1 = aleat.Next(0, matrice.GetLength(0));
                position2 = aleat.Next(0, matrice.GetLength(1));

                if (matrice[position1, position2] == 4 || matrice[position1, position2] == 1)         //si la cellule est déja vivante, on ne la compte pas et on va en générer une de plus
                {                                                                                     //si on tombe sur une cellule de la premiere generation, on continue de même
                    n = n;
                }
                else
                {
                    matrice[position1, position2] = 4;      //si la cellule n'est pas déja vivante, on la compte et on continue
                    n = n + 1;
                }
            }
        }

        static void Afficher_Interface(int[,] matrice)       //Permet d'afficher l'interface graphique du jeu de la vie dans la console (cas AVEC à naitre et à mourir)
        {
            int n = 0;
            while (n < matrice.GetLength(0))
            {
                for (int i = 0; i < matrice.GetLength(1); i++)
                {
                    if (matrice[n, i] == 1)     //cellule vivante
                    {

                        Console.Write("# ");
                    }
                    else if (matrice[n, i] == 0)    //cellule morte
                    {

                        Console.Write(". ");
                    }
                    else if (matrice[n, i] == 2)    //cellule à naitre
                    {

                        Console.Write("- ");
                    }
                    else if (matrice[n, i] == 3)    //cellule à mourir
                    {

                        Console.Write("* ");
                    }
                        else if (matrice[n, i] == 4)    //cellule vivante 2ème population
                    {

                        Console.Write("v ");
                    }
                    else if (matrice[n, i] == 5)    //cellule à naitre
                    {

                        Console.Write("+ ");
                    }
                    else if (matrice[n, i] == 6)    //cellule à mourir
                    {

                        Console.Write("m ");
                    }
                    else
                    {
                        Console.Write("@ "); ;
                    }
                }
                Console.WriteLine("");
                n = n + 1;
            }
        }

        static void Afficher_Interface_Sans_Futur(int[,] matrice)       //Permet d'afficher l'interface graphique du jeu de la vie dans la console (cas SANS à naitre et à mourir)
        {
            int n = 0;
            while (n < matrice.GetLength(0))
            {
                for (int i = 0; i < matrice.GetLength(1); i++)
                {
                    if (matrice[n, i] == 1)     //cellule vivante
                    {

                        Console.Write("# ");
                    }
                    else if (matrice[n, i] == 0)    //cellule morte
                    {

                        Console.Write(". ");
                    }
                    else if (matrice[n, i] == 4)    //cellule vivante autrepopulation
                    {

                        Console.Write("v ");
                    }
                    else                            //cas ou un nombre est différent de1 et 2, permet un retour sur erreur
                    {
                        Console.Write("@ "); ;
                    }
                }
                Console.WriteLine("");
                n = n + 1;
            }
        }

        static void Changement(int[,]matrice)                         //   Pour changer les à naitre et à mourir en cellules normales
        {
            int n = 0;
            while (n < matrice.GetLength(0))
            {
                for (int i = 0; i < matrice.GetLength(1); i++)
                {
                    if (matrice[n, i] == 2)                 //on passe les a naitre en vivantes
                    {
                        matrice[n, i] = 1;
                    }
                    else if (matrice[n, i] == 3)            //on passe les a mourir en morte
                    {
                        matrice[n, i] = 0;
                    }

                    else if (matrice[n, i] == 5)
                    {                               //on passe les a naitre en vivantes pour la deuxième population
                        matrice[n, i] = 4;
                    }
                    else if (matrice[n, i] == 6)            //on passe les a mourir en morte pour la deuxième population (je ne groupe pas pour m'y retrouver)
                    {
                        matrice[n, i] = 0;
                    }
                }
                n = n + 1;
            }
        }

        static int Taille_Génération(int[,] matrice)            //Compte le nombre de cellules vivantes dans la matrice finale pour une population  
        {
            int compte = 0;
            int n = 0;
            while (n < matrice.GetLength(0))
            {
                for (int i = 0; i < matrice.GetLength(1); i++)
                {
                    if (matrice[n, i] == 1)                 //pour chaque cellule vivantes on ajoute 1 au compte
                    {
                        compte = compte + 1;
                    }
                    else
                    {
                        compte = compte;
                    }
                }
                n = n + 1;
            }
            return compte;
        }

        static int Taille_Génération2(int[,] matrice)            //Compte le nombre de cellules vivantes dans la matrice finale pour la deuxième population  
        {
            int compte = 0;
            int n = 0;
            while (n < matrice.GetLength(0))
            {
                for (int i = 0; i < matrice.GetLength(1); i++)
                {
                    if (matrice[n, i] == 4)                 //pour chaque cellule vivantes on ajoute 1 au compte
                    {
                        compte = compte + 1;
                    }
                    else
                    {
                        compte = compte;
                    }
                }
                n = n + 1;
            }
            return compte;
        }

        static int Etat_Cellule(int[,]matrice,int Lignes, int Colonne)    //compte le nbr de cellules vivantes autour d'une cellule     
           {
                int compteur = 0;
                    int[,] positionsRelatives = { { -1, 1 }, { 0, 1 }, { 1, 1 }, { 1, 0 }, { 1, -1 }, { 0, -1 }, { -1, -1 }, { -1, 0 } };           //on vérifie les8 positions autour de notre case

                    for (int n = 0; n < 8; n++)
                    {
                        int LigneaVerifier = Lignes + positionsRelatives[n, 0];                // Ligne de la position a verifier
                        LigneaVerifier=ConnexionLigne(matrice, LigneaVerifier);                //on vérifie que la ligne est dans la matrice et on corrige

                        int ColonneaVerifier = Colonne + positionsRelatives[n, 1];             // Colonne de la position a verifier  
                        ColonneaVerifier = ConnexionColonne(matrice, ColonneaVerifier);        //on vérifie que la ligne est dans la matrice

                if (matrice[LigneaVerifier, ColonneaVerifier] == 1)                         // si la cellule a la position a verifier est vivante et on corrige
                    compteur = compteur + 1;
            }
            return compteur;
           }

        static int Etat_Cellule_2ème_population(int[,] matrice, int Lignes, int Colonne) //INCOMPLET   //compte le nbr de cellules vivantes autour d'une cellule     
        {
            int compteur = 0;
            int[,] positionsRelatives = { { -1, 1 }, { 0, 1 }, { 1, 1 }, { 1, 0 }, { 1, -1 }, { 0, -1 }, { -1, -1 }, { -1, 0 } };           //on vérifie les8 positions autour de notre case

            for (int n = 0; n < 8; n++)
            {
                int LigneaVerifier = Lignes + positionsRelatives[n, 0];                // Ligne de la position a verifier
                LigneaVerifier = ConnexionLigne(matrice, LigneaVerifier);                //on vérifie que la ligne est dans la matrice et on corrige

                int ColonneaVerifier = Colonne + positionsRelatives[n, 1];             // Colonne de la position a verifier  
                ColonneaVerifier = ConnexionColonne(matrice, ColonneaVerifier);        //on vérifie que la ligne est dans la matrice

                if (matrice[LigneaVerifier, ColonneaVerifier] == 4)                         // si la cellule a la position a verifier est vivante et on corrige
                    compteur = compteur + 1;
            }
            return compteur;
        }

        static int Etat_Cellule_rang2(int[,] matrice, int Lignes, int Colonne)    //compte le nbr de cellules vivantes autour d'une cellule     
        {
            int compteur = 0;
            int[,] positionsRelatives = { { -2, -2 }, { -1, -2 }, { 0, -2 }, { 1, -2 }, { 2, -2 }, { -2, -1 }, { 2, -1 }, { -2, 0 }, { 2, 0 }, { -2, 1 }, { 2, 1 }, { -2, 2 }, { -1, 2 }, { 0, 2 }, { 1, 2 }, { 2, 2 } };           //on vérifie les8 positions autour de notre case

            for (int n = 0; n < 16; n++)
            {
                int LigneaVerifier = Lignes + positionsRelatives[n, 0];                // Ligne de la position a verifier
                LigneaVerifier = ConnexionLigne(matrice, LigneaVerifier);                //on vérifie que la ligne est dans la matrice et on corrige

                int ColonneaVerifier = Colonne + positionsRelatives[n, 1];             // Colonne de la position a verifier  
                ColonneaVerifier = ConnexionColonne(matrice, ColonneaVerifier);        //on vérifie que la ligne est dans la matrice

                if (matrice[LigneaVerifier, ColonneaVerifier] == 1)                         // si la cellule a la position a verifier est vivante 
                    compteur = compteur + 1;
            }
            return compteur;
        }

        static int Etat_Cellule_rang2_2èmepopulation(int[,] matrice, int Lignes, int Colonne)    //compte le nbr de cellules vivantes autour d'une cellule     
        {
            int compteur = 0;
            int[,] positionsRelatives = { { -2, -2 }, { -1, -2 }, { 0, -2 }, { 1, -2 }, { 2, -2 }, { -2, -1 }, { 2, -1 }, { -2, 0 }, { 2, 0 }, { -2, 1 }, { 2, 1 }, { -2, 2 }, { -1, 2 }, { 0, 2 }, { 1, 2 }, { 2, 2 } };           //on vérifie les8 positions autour de notre case

            for (int n = 0; n < 16; n++)
            {
                int LigneaVerifier = Lignes + positionsRelatives[n, 0];                // Ligne de la position a verifier
                LigneaVerifier = ConnexionLigne(matrice, LigneaVerifier);                //on vérifie que la ligne est dans la matrice et on corrige

                int ColonneaVerifier = Colonne + positionsRelatives[n, 1];             // Colonne de la position a verifier  
                ColonneaVerifier = ConnexionColonne(matrice, ColonneaVerifier);        //on vérifie que la ligne est dans la matrice

                if (matrice[LigneaVerifier, ColonneaVerifier] == 4)                         // si la cellule a la position a verifier est vivante 
                    compteur = compteur + 1;
            }
            return compteur;
        }

        static void CopierMatrice(int[,] matrice, int[,] matriceSuivante)       //copie une matrice dans une autre--------->ATTENTION à l'ordre des matrices lorsque l'on copie/colle
        {
            int a = 0;                              
            while (a < matrice.GetLength(0))
            {
                for (int i = 0; i < matrice.GetLength(1); i++)
                {
                    matrice[a, i] = matriceSuivante[a, i];
                }
                a = a + 1;
            }
        }

        static int[,] Générer(int[,]matrice)            //Génère une 2ème matrice et la remplie selon le nbr de cellules vivantes autour de la première puis copie la seconde matrice dansla 1ère SANS les cas a naitre et a mourir
        {
            int[,] matriceSuivante = new int[matrice.GetLength(0), matrice.GetLength(1)]; // Matrice temporaire pour le calcul

            // Vérifie pour chaque cellule de la matrice usuelle
            for (int Ligne = 0; Ligne < matrice.GetLength(0); Ligne++)
            {
                for (int Colonne = 0; Colonne < matrice.GetLength(1); Colonne++)
                {                   
                    if (matrice[Ligne, Colonne]==1)
                    {
                        int nbVivantesAutour = Etat_Cellule(matrice, Ligne, Colonne);           // Nombre de cellules vivantes qui entourent la cellule en test

                        if (nbVivantesAutour == 2 || nbVivantesAutour == 3)
                        {
                            matriceSuivante[Ligne, Colonne] = 1; // La cellule reste en vie
                        }
                        else
                        {
                            matriceSuivante[Ligne, Colonne] = 0; // La cellule meurt
                        }
                    }
                    else if (matrice[Ligne, Colonne] == 4)
                    {
                        int nbVivantesAutour = Etat_Cellule_2ème_population(matrice, Ligne, Colonne);           // Nombre de cellules vivantes qui entourent la cellule en test

                        if (nbVivantesAutour == 2 || nbVivantesAutour == 3)
                        {
                            matriceSuivante[Ligne, Colonne] = 4; // La cellule reste en vie
                        }
                        else
                        {
                            matriceSuivante[Ligne, Colonne] = 0; // La cellule meurt
                        }
                    }
                    else if(matrice[Ligne, Colonne] == 0)                   //pour le cas ou la cellule est morte, on vérifie que les 2 populations sont égale à 3
                    {
                        int nbVivantesAutour1 = Etat_Cellule(matrice, Ligne, Colonne);
                        int nbVivantesAutour2 = Etat_Cellule_2ème_population(matrice, Ligne, Colonne);

                        if(nbVivantesAutour1==nbVivantesAutour2&& nbVivantesAutour2 == 3)
                        {
                            if(Etat_Cellule_rang2( matrice,  Ligne,  Colonne)> Etat_Cellule_rang2_2èmepopulation( matrice,  Ligne,  Colonne))
                            {
                                matriceSuivante[Ligne, Colonne] = 1;
                            }
                            else if (Etat_Cellule_rang2(matrice, Ligne, Colonne) < Etat_Cellule_rang2_2èmepopulation(matrice, Ligne, Colonne))
                            {
                                matriceSuivante[Ligne, Colonne] = 4;
                            }
                            else
                            {
                                matriceSuivante[Ligne, Colonne] = 0;
                            }
                        }
                        else if (nbVivantesAutour1 != nbVivantesAutour2 && nbVivantesAutour2 == 3)
                        {
                            matriceSuivante[Ligne, Colonne] = 4;
                        }
                        else if (nbVivantesAutour1 != nbVivantesAutour2 && nbVivantesAutour1 == 3)
                        {
                            matriceSuivante[Ligne, Colonne] = 1;
                        }
                        else
                        {
                                            //Je ne prends pas en compte les cas d'égalité car cela m'obligerait a refaire mon code entièrement et à repenser toutes mes fonctions
                        }
                        {
                            matriceSuivante[Ligne, Colonne] = 0;
                        }
                    }
                }
            }
            CopierMatrice(matrice, matriceSuivante); // Recopie la matrice temporaire dans la matrice usuelle
            return matrice;
        }

        static int[,] GénérerFutur(int[,] matrice)            //Génère une 2ème matrice et la remplie selon le nbr de cellules vivantes autour de la première puis copie la seconde matrice dansla 1ère AVEC les cas a naitre et a mourir
        {
            int[,] matriceSuivante = new int[matrice.GetLength(0), matrice.GetLength(1)]; // Matrice temporaire pour le calcul

            // Vérifie pour chaque cellule de la matrice usuelle
            for (int Ligne = 0; Ligne < matrice.GetLength(0); Ligne++)
            {
                for (int Colonne = 0; Colonne < matrice.GetLength(1); Colonne++)
                {
                    if (matrice[Ligne, Colonne] == 1)
                    {
                        int nbVivantesAutour = Etat_Cellule(matrice, Ligne, Colonne);           // Nombre de cellules vivantes qui entourent la cellule en test

                        if (nbVivantesAutour == 2 || nbVivantesAutour == 3)
                        {
                            matriceSuivante[Ligne, Colonne] = 1; // La cellule reste en vie
                        }
                        else
                        {
                            matriceSuivante[Ligne, Colonne] = 3; // La cellule va mourir
                        }
                    }
                    else if (matrice[Ligne, Colonne] == 4)
                    {
                        int nbVivantesAutour = Etat_Cellule_2ème_population(matrice, Ligne, Colonne);           // Nombre de cellules vivantes qui entourent la cellule en test

                        if (nbVivantesAutour == 2 || nbVivantesAutour == 3)
                        {
                            matriceSuivante[Ligne, Colonne] = 4; // La cellule reste en vie
                        }
                        else
                        {
                            matriceSuivante[Ligne, Colonne] = 6; // La cellule va mourir
                        }
                    }
                    else if (matrice[Ligne, Colonne] == 0)                   //pour le cas ou la cellule est morte, on vérifie que les 2 populations sont égale à 3
                    {
                        int nbVivantesAutour1 = Etat_Cellule(matrice, Ligne, Colonne);
                        int nbVivantesAutour2 = Etat_Cellule_2ème_population(matrice, Ligne, Colonne);

                        if (nbVivantesAutour1 == nbVivantesAutour2 && nbVivantesAutour2 == 3)
                        {
                            if (Etat_Cellule_rang2(matrice, Ligne, Colonne) > Etat_Cellule_rang2_2èmepopulation(matrice, Ligne, Colonne))
                            {
                                matriceSuivante[Ligne, Colonne] = 2;        //la cellule va naitre
                            }
                            else if (Etat_Cellule_rang2(matrice, Ligne, Colonne) < Etat_Cellule_rang2_2èmepopulation(matrice, Ligne, Colonne))
                            {
                                matriceSuivante[Ligne, Colonne] = 5;        //la cellule va naitre
                            }
                            else
                            {
                                matriceSuivante[Ligne, Colonne] = 0;
                            }
                        }
                        else if (nbVivantesAutour1 != nbVivantesAutour2 && nbVivantesAutour2 == 3)
                        {
                            matriceSuivante[Ligne, Colonne] = 5;
                        }
                        else if (nbVivantesAutour1 != nbVivantesAutour2 && nbVivantesAutour1 == 3)
                        {
                            matriceSuivante[Ligne, Colonne] = 2;
                        }
                        else                                                   //Je ne prends pas en compte les cas d'égalité car cela m'obligerait a refaire mon code entièrement et à repenser toutes mes fonctions                       
                        {
                            matriceSuivante[Ligne, Colonne] = 0;
                        }
                    }
                }
            }
            CopierMatrice(matrice, matriceSuivante); // Recopie la matrice temporaire dans la matrice usuelle
            return matrice;
        }


        static void Menu1()            //SANS       Menu qui lance l'interface sans Futur
        {
            int n = 0;
            int[,] matrice = Choix_Création();
            Remplissage_Matrice(matrice);
            Afficher_Interface_Sans_Futur(matrice);
            Fenetre gui = new Fenetre(matrice, 20, 0, 0, "Jeu de la vie");
            Console.WriteLine("Génération de départ: " + n);
            Console.WriteLine(Taille_Génération(matrice) + " cellules vivantes");
            Console.WriteLine("");


             
            while (n<100000)         //Très Grand Compteur pour des générations infinis
            {
                matrice=Générer(matrice);
                Afficher_Interface_Sans_Futur(matrice);
                gui.RafraichirTout();
                gui.changerMessage("Gris = mortes   noir = vivantes");
                n = n + 1;
                Console.WriteLine("Génération "+n);
                Console.WriteLine(Taille_Génération(matrice)+" cellules vivantes");
                Console.ReadKey();
                if(Taille_Génération(matrice)==0)
                {
                    n = n + 100000;
                    Console.WriteLine("Fin du jeu, plus de vie");
                }
            }

        }

        static void Menu2()             //AVEC      Menu qui lance l'interface avec Futur
        {
            int n = 0;
            int[,] matrice = Choix_Création();
            Remplissage_Matrice(matrice);
            Afficher_Interface(matrice);
            Fenetre gui = new Fenetre(matrice, 20, 0, 0, "Jeu de la vie");
            Console.WriteLine("Génération de départ: " + n);
            Console.WriteLine(Taille_Génération(matrice) + " cellules vivantes");
            Console.WriteLine("");
            Console.ReadKey();

            while (n < 100000)         //Très Grand Compteur pour des générations infinis
            {
                matrice = GénérerFutur(matrice);
                Afficher_Interface(matrice);
                gui.RafraichirTout();
                gui.changerMessage("Gris = mortes   noir = vivantes   vert = à naitre    rouges = a mourir");
                Console.ReadKey();
                Console.WriteLine("");
                Changement(matrice);
                Afficher_Interface(matrice);
                gui.RafraichirTout();
                n = n + 1;
                Console.WriteLine("Génération " + n);
                Console.WriteLine(Taille_Génération(matrice) + " cellules vivantes");
                Console.ReadKey();
                if (Taille_Génération(matrice) == 0)
                {
                    n = n + 100000;
                    Console.WriteLine("Fin du jeu, plus de vie");
                }
            }

        }

        static void Menu3()             //DOUBLE POPULATION //SANS futur
        {
            int n = 0;
            int[,] matrice = Choix_Création();
            Remplissage_Matrice_2_populations(matrice);
            Afficher_Interface_Sans_Futur(matrice);
            Fenetre gui = new Fenetre(matrice, 20, 0, 0, "Jeu de la vie");
            gui.changerMessage("Gris = mortes   noir = vivantes1  bleu = vivantes 2");
            Console.WriteLine("Génération de départ: " + n);
            Console.WriteLine(Taille_Génération(matrice) + " cellules vivantes de la première population");
            Console.WriteLine(Taille_Génération2(matrice) + " cellules vivantes de la deuxième population");
            Console.WriteLine("");
            Console.ReadKey();

            while (n < 1000000)         //Très Grand Compteur pour des générations infinis //INCOMPLET
            {
                matrice = Générer(matrice);
                Afficher_Interface_Sans_Futur(matrice);
                gui.RafraichirTout();
                n = n + 1;
                Console.WriteLine("Génération " + n);
                Console.WriteLine(Taille_Génération(matrice) + " cellules vivantes de la première population");
                Console.WriteLine(Taille_Génération2(matrice) + " cellules vivantes de la deuxième population");
                Console.ReadKey();
                if (Taille_Génération(matrice) == 0 && Taille_Génération2(matrice)==0)
                {
                    n = n + 1000000;
                    Console.WriteLine("Fin du jeu, plus de vie");
                }
            }
        }

        static void Menu4()             //DOUBLE POPULATION //AVEC futur
        {
            int n = 0;
            int[,] matrice = Choix_Création();
            Remplissage_Matrice_2_populations(matrice);
            Afficher_Interface(matrice);
            Fenetre gui = new Fenetre(matrice, 20, 0, 0, "Jeu de la vie");
            gui.changerMessage("Gris = mortes   noir = vivantes1   vert = à naitre1    rouges = a mourir1");
            Console.ReadKey();
            gui.changerMessage("Gris = mortes   bleu = vivantes2   jaune = à naitre2    orange = a mourir2");
            Console.WriteLine("Génération de départ: " + n);
            Console.WriteLine(Taille_Génération(matrice) + " cellules vivantes de la première population");
            Console.WriteLine(Taille_Génération2(matrice) + " cellules vivantes de la deuxième population");
            Console.WriteLine("");
            Console.ReadKey();

            while (n < 1000000)         //Très Grand Compteur pour des générations infinis //INCOMPLET
            {
                matrice = GénérerFutur(matrice);
                Afficher_Interface(matrice);
                gui.RafraichirTout();
                Console.ReadKey();
                Console.WriteLine("");
                Changement(matrice);
                Afficher_Interface(matrice);
                gui.RafraichirTout();
                n = n + 1;
                Console.WriteLine("Gris = mortes   noir = vivantes1   vert = à naitre1    rouges = a mourir1");
                Console.WriteLine("Gris = mortes   bleu = vivantes2   jaune = à naitre2    orange = a mourir2");
                Console.WriteLine();
                Console.WriteLine("Génération " + n);
                Console.WriteLine(Taille_Génération(matrice) + " cellules vivantes de la première population");
                Console.WriteLine(Taille_Génération2(matrice) + " cellules vivantes de la deuxième population");
                Console.ReadKey();
                if (Taille_Génération(matrice) == 0 && Taille_Génération2(matrice) == 0)
                {
                    n = n + 1000000;
                    Console.WriteLine("Fin du jeu, plus de vie");
                }
            }
        }

        [System.STAThreadAttribute()]
        static void Main(string[] args)
         {
            Menu();
            
             Console.ReadKey();
         }
    }
}
