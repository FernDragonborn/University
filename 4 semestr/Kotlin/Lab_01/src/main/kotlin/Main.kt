import kotlin.math.*

fun main() {
    println("Starting x: ")
    var xStart: Int =  readlnOrNull()?.toIntOrNull() ?: 0
    println("Ending x: ")
    var xEnd : Int = readlnOrNull()?.toIntOrNull() ?: 0
    if(xStart > xEnd){
        xStart = xEnd.also { xEnd = xStart }
    }
    val a = (0..10).random()
    println("Coefficient: $a")

    var stepsCount = xEnd - xStart
    var step : Float = 1.0f
    if(stepsCount > 100) {
        step = (stepsCount) / 100f
        stepsCount = 100
    }

    for(i in 0..stepsCount){
        val x  = step * i
        val y : Double = x + (5.0 / ((3 * x) / a)) + (ln(abs(cos(a.toDouble()))) / 2 / exp(a.toDouble())) + (1.0e-5 * x.pow(3))
        println("x: ${String.format("%.3f",x)}\ty: ${String.format("%.3f",y)}")
    }
}