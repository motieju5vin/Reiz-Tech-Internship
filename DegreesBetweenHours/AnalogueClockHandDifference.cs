using System.Net.NetworkInformation;

namespace DegreesBetweenHours {
    //Calculates the difference between analogue clock hands
    public static class AnalogueClockHandDifference {
        private const int DEGREES_IN_MINUTE = 360 / 60; 
        private const int DEGREES_IN_HOUR = 360 / 12;
        private const bool CHECK_HOURS = true, CHECK_MINUTES = false;
        private static int hours = 0, minutes = 0;
        private static bool isFirstTime = true;
        private static int ValidateInput(string input,bool option) {

            if (input == "") {
                Console.WriteLine("Incorrect input, the field is empty\n");
                return 1;
            }
            if(input.Length > 2) {
                Console.WriteLine("Incorrect input, the entered number is too long\n");
                return 1;
            }
            if (option == CHECK_HOURS) {
                if (!int.TryParse(input, out hours)) {
                    Console.WriteLine("Incorrect input,either one or both of the inputs weren't digits, or the number was too large\n");
                    return 1;
                }
                
                if (hours < 1 || hours > 12) {
                    Console.WriteLine("Incorrect input, the entered time is not valid\n");
                    return 1;
                }
                return 0;
            }
            if (!int.TryParse(input, out minutes)) {
                Console.WriteLine("Incorrect input,either one or both of the inputs weren't digits, or the number was too large\n");
                return 1;
            }
            if (minutes < 0 || minutes >= 60) {
                Console.WriteLine("Incorrect input, the entered time is not valid\n");
                return 1;
            }
            return 0;
            
        }
        private static int CalculateDifference(int minDegrees, int hDegrees) {
            int degDifference = 0;
            if (minDegrees > hDegrees) {
                degDifference = minDegrees - hDegrees;
            }
            else {
                degDifference = hDegrees - minDegrees;
            }

            if (degDifference > 180) {
                degDifference = 360 - degDifference;
            }
            return degDifference;
        }
        public static int Start() {
            int minDegrees = 0, hDegrees = 0;
            if (isFirstTime) {
                Console.Write("This app calculates the lesser angle difference in degrees between two analogue clock hands\n" +
                        "Please only input the numbers, without 'Min' or 'h' and 'PM' or 'AM'\n" +
                        "Please use 12-hours clock format\n\n");
                isFirstTime = false;
            }
            Console.Write("Input Hours: ");
            string? hoursString = Console.ReadLine().Trim();
            if(ValidateInput(hoursString, CHECK_HOURS) != 0) { return 1; }
            Console.Write("Input Minutes: ");
            string? minutesString = Console.ReadLine().Trim();
            if (ValidateInput(minutesString, CHECK_MINUTES) != 0) { return 1; }
            
            minDegrees = minutes * DEGREES_IN_MINUTE;
            hDegrees = hours * DEGREES_IN_HOUR;
            int degDifference = CalculateDifference(minDegrees, hDegrees);
            Console.WriteLine($"Difference: {degDifference} Degrees\n");
            return 0;
        }
    }
}
