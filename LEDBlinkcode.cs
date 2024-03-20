const int buttonPin = 4; // Pin connected to the push button
const int ledPin = 13;   // Pin connected to the LED

const char* morseCode[] = {".-.", "---", "-.", "--.", "-..", "..-"};

void setup() {
  pinMode(buttonPin, INPUT); // Set the push button pin as input
  pinMode(ledPin, OUTPUT);   // Set the LED pin as output
}

void loop() {
  if (digitalRead(buttonPin) == HIGH) { // Check if the push button is pressed
    blinkName(); // Start blinking the name in Morse code
  }
}

void blinkName() {
  for (const char* letter : morseCode) {
    for (char symbol : String(letter)) {
      blinkSymbol(symbol);
    }
    delay(500); // Inter-letter gap
  }
  delay(1000); // Wait for one second after completing the blink cycle
}

void blinkSymbol(char symbol) {
  digitalWrite(ledPin, HIGH); // Turn on the LED for dot or dash
  delay(symbol == '.' ? 250 : 750); // Dot duration: 250ms, Dash duration: 750ms
  digitalWrite(ledPin, LOW); // Turn off the LED
  delay(250); // Inter-element gap
}