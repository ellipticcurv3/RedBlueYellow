#include <Mouse.h>
#include <Keyboard.h>

/*   
 *   Design & Code by
 *   
 *   Ricardo Balk
 *   
 *   January, 2016
 *   
 *   E-mail:    programming@ricardobalk.nl
 *   Web:       ricardo.nu/programming
 *   Telephone: +31 24 301 0005
 *   
 */


/*    Compiler pre-processor variabelen
 *     Gebruikt minder geheugen dan het definiëren van integers
 */

#define DEBUG_NEE
#define SERIAL_SPEED 56700
#define KEYMOUSEDELAY 5000

/*    Aansluitingen
 *     Op welke aansluitingen zitten de fysieke controls?
 */

#define RED_BUTTON_PIN    11
#define BLUE_BUTTON_PIN   10
#define YELLOW_BUTTON_PIN 9
#define JOYSTICK_X_PIN    A1
#define JOYSTICK_Y_PIN    A0
#define JOYSTICK_BUTTON   A2
#define LED               13

/*    Controls (keyboard mapping) - zie https://www.arduino.cc/en/Reference/MouseKeyboard
 *     Zet onderstaande welke controls er gebruikt worden
 */

#define KEYBOARD_RED      '1'
#define KEYBOARD_BLUE     '2'
#define KEYBOARD_YELLOW   '3'

#define MOUSE_BUTTON MOUSE_LEFT
#define MOUSE_N_SPEED     -7
#define MOUSE_P_SPEED     7

boolean STATE_LEFT  = 1,
        STATE_RIGHT = 1,
        STATE_UP    = 1,
        STATE_DOWN  = 1,
        STATE_RED   = 1,
        STATE_BLUE  = 1,
        STATE_YELLOW = 1,
        STATE_JOYSTICK_BUTTON = 1;

void setup() {
  delay(KEYMOUSEDELAY);

  // SET-UP
  Keyboard.begin();                                   // Keyboard inschakelen
  delay(1200);
  Mouse.begin();                                   // Mouse inschakelen
  
  pinMode(13, OUTPUT);                                // LED is een output
  digitalWrite(13, LOW);                              // LED staat uit

  /*
   * Pull-up weerstanden...
   * 
   * Normaal gesproken zit een knop als volgt aangesloten:
   * 
   *                  /
   *   (5 volt) -----o  o-----=====> (Arduino Input)
   *                 Knop    /
   *                         \ 10 kOhm
   *                         / Pull down
   *                         \ weerstand
   *                         /
   *                        ___ aarde (-)
   *                
   * Deze constructie zorgt ervoor dat de stroom die nog in de draad zit weglekt naar de aarde (-)
   * en dat de Arduino de input ziet als LOW zodra je de knop loslaat.
   * 
   * Maar het is ook mogelijk om de knop te schakelen met aarde (- / 0 volt) en gebruik te maken van een pull-up weerstand,
   * dan leest de Arduino HIGH uit als de knop niet ingedrukt is.
   * Het voordeel: Een Arduino heeft ingebouwde pull-up weerstanden; dus je hoeft geen extra weerstand tussen de knop en 5 volt te zetten.
   * 
   *                       (5 VOLT)
   *                          /
   *                          \ 10 kOhm
   *                          / Pull up
   *                          \ weerstand (INGEBOUWD)
   *                  /       /
   *   (0 volt) -----o  o-----=====> (Arduino Input)
   *                 Knop
   *                 
   *  Je gebruikt dit door: pinMode(pin, INPUT) te vervangen door pinMode(pin, INPUT_PULLUP)
   *  
   *  En bij het uitlezen zet je eenvoudig een ! voor je statement; praktisch gezien keer je de waarde dan om:
   *  if(!digitalRead(pin)) { Serial.println("De pin is ingedrukt"); } betekent: als digitale uitgang van pin NIET hoog is....
   *  Dan is de knop ingedrukt. Want de pull-up weerstand zorgt ervoor dat het net andersom werkt.
   */
  
  pinMode(RED_BUTTON_PIN, INPUT_PULLUP);
  pinMode(BLUE_BUTTON_PIN, INPUT_PULLUP);
  pinMode(YELLOW_BUTTON_PIN, INPUT_PULLUP);
  pinMode(JOYSTICK_X_PIN, INPUT_PULLUP);
  pinMode(JOYSTICK_Y_PIN, INPUT_PULLUP);
  pinMode(JOYSTICK_BUTTON, INPUT_PULLUP);
}

void loop() {
    checkButtons();
    //heartbeatLED();
}

void checkButtons(){
  if (STATE_RED != digitalRead(RED_BUTTON_PIN)){
      STATE_RED = digitalRead(RED_BUTTON_PIN);
  }

  if (STATE_BLUE != digitalRead(BLUE_BUTTON_PIN)){
      STATE_BLUE = digitalRead(BLUE_BUTTON_PIN);
  }

  if (STATE_YELLOW != digitalRead(YELLOW_BUTTON_PIN)){
      STATE_YELLOW = digitalRead(YELLOW_BUTTON_PIN);
  }

  if (STATE_JOYSTICK_BUTTON != digitalRead(JOYSTICK_BUTTON)){
     STATE_JOYSTICK_BUTTON = digitalRead(JOYSTICK_BUTTON);
  }

  delay(2);
  if(!STATE_RED){ Keyboard.press(KEYBOARD_RED); delay(2); } else { Keyboard.release(KEYBOARD_RED); delay(2); }
  if(!STATE_BLUE){ Keyboard.press(KEYBOARD_BLUE); delay(2); } else { Keyboard.release(KEYBOARD_BLUE); delay(2); }
  if(!STATE_YELLOW){ Keyboard.press(KEYBOARD_YELLOW); delay(2); } else { Keyboard.release(KEYBOARD_YELLOW); delay(2); }
  if(!STATE_JOYSTICK_BUTTON){ Mouse.press(MOUSE_BUTTON); delay(2); } else { Mouse.release();}

  if(analogRead(JOYSTICK_X_PIN) < 100) {
    // Rechts
    Mouse.move(MOUSE_P_SPEED,0);
  } else if((analogRead(JOYSTICK_X_PIN) > 150) && (analogRead(JOYSTICK_X_PIN) < 800)){
    // Links!
    Mouse.move(MOUSE_N_SPEED,0);
  } else if (analogRead(JOYSTICK_X_PIN) > 900) {
    // Pull-up: Geen richting.
  }

  if(analogRead(JOYSTICK_Y_PIN) < 100) {
    Mouse.move(0,MOUSE_P_SPEED);
  } else if((analogRead(JOYSTICK_Y_PIN) > 150) && (analogRead(JOYSTICK_Y_PIN) < 800)){
    Mouse.move(0,MOUSE_N_SPEED);
  } else if (analogRead(JOYSTICK_Y_PIN) > 900) {
    // Pull-up: Geen richting.
  }
  
  if(!STATE_RED || !STATE_BLUE || !STATE_YELLOW || !STATE_JOYSTICK_BUTTON){ delay(2);  digitalWrite(13, HIGH); } else { digitalWrite(13, LOW); }
}

void heartbeatLED(){
        for (byte t = 255; t >= 0; t = t - 1){
          analogWrite(13, t); delay(5);
        }
        delay(200);
}
