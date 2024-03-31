import kotlin.math.*

fun main() {
    var xStart: Int = 0
    var xEnd: Int = 0
    var isSucces: Boolean = false
    
    do {
        try {
            xStart = readln().toInt()
            isSucces = true
        } catch (ex: NumberFormatException) {
            println("Error: Invalid value entered. Try again.")
        }
    } while (!isSucces)

    isSucces = false
    print("Ending x: ")
    do {
        try {
            xEnd = readln().toInt()
            isSucces = true
        } catch (ex: NumberFormatException) {
            println("Error: Invalid value entered. Try again.")
        }
    } while (!isSucces)


    if (xStart > xEnd) {
        xStart = xEnd.also { xEnd = xStart }
    }
    val a = (0..10).random()
    println("Coefficient: $a")

    var stepsCount = xEnd - xStart
    var step: Float = 1.0f
    if (stepsCount > 100) {
        step = (stepsCount) / 100f
        stepsCount = 100
    }

    var table = arrayOf(
        DoubleArray(stepsCount),
        DoubleArray(stepsCount)
    )

    for (i in 0..<stepsCount) {
        val x = step.toDouble() * i
        val y = getY(x, a)
        table[0][i] = x
        table[1][i] = y
    }
    for (i in 0..<stepsCount) {
        println("x: ${String.format("%.3f", table[0][i])}\ty: ${String.format("%.3f", table[1][i])}")
    }
}

fun getY(x: Double, a: Int) =
    x + (5.0 / ((3 * x) / a)) + (ln(abs(cos(a.toDouble()))) / 2 / exp(a.toDouble())) + (1.0e-5 * x.pow(3))

