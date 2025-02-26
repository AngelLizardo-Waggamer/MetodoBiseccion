/*
    Autor: Ángel Andrés Hernández Lizardo
    Github: @AngelLizardo-Waggamer
    Fecha: 25/02/2025
*/

// Ecuación a resolver y = x^3 - 4x - 9
double f(double x) { return Math.Pow(x, 3.0) - 4*x - 9; }

// Intervalo en forma [a,b]
double a = 2;
double b = 3;

// Punto medio
double pM(double a, double b) { return (a + b) / 2; }

// Calculo de error
double cErr(double a, double b) { return Math.Abs((b - a) / 2); }

// Error
double errorInicial = 0.001;

// Limite de iteraciones
int n = 1000;

// Solución
for (int i = 0; i < n; i++) {

    bool aPositivo = false, bPositivo = false, puntoMedioPositivo = false;

    // 1.- Calcular el punto medio
    double puntoMedio = pM(a, b);

    // 2.- Evaluar el punto medio en la función así como los puntos definidos anteriormente
    double fDeA = f(a);
    double fPuntoMedio = f(puntoMedio);
    double FDeB = f(b);

    // 2.5-> Verificar si el punto medio es la raiz
    if(fPuntoMedio == 0) {
        Console.WriteLine($"Iteración: {i + 1}");
        Console.WriteLine($"Raiz Aproximada: {f(puntoMedio)}");
        Console.WriteLine($"Error: {errorInicial}");
        break;
    }

    // 3.- Verificar los signos de los valores obtenidos
    if(fDeA > 0) aPositivo = true;
    if(FDeB > 0) bPositivo = true;
    if(fPuntoMedio > 0) puntoMedioPositivo = true;

    if(aPositivo && puntoMedioPositivo) {
        a = puntoMedio;
    } else if (bPositivo && puntoMedioPositivo) {
        b = puntoMedio;
    }else if(aPositivo && !puntoMedioPositivo) {
        b = puntoMedio;
    } else if(bPositivo && !puntoMedioPositivo) {
        a = puntoMedio;
    }

    // 4.- Calcular el error
    double errorCalculado = cErr(a, b);

    if(errorCalculado <= errorInicial) {
        Console.WriteLine($"Iteración: {i + 1}");
        Console.WriteLine($"Raiz Aproximada: {puntoMedio}");
        Console.WriteLine($"Error: {errorCalculado}");
        break;
    }
}