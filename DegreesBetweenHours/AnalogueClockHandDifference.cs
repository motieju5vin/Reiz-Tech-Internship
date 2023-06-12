namespace DegreesBetweenHours {
    public static class AnalogueClockHandDifference {
        private const int DEGREES_IN_MINUTE = 360 / 60; //360 degrees in a circle divided into 60 minutes
        private const int DEGREES_IN_HOUR = 360 / 12; //360 degrees in a circle divided into 12 hours
        private static int hours = 0, minutes = 0;
        private static int ValidateAndSplitInput(string time) {
            string minutesString = "", hoursString = "";
            if (!time.Contains(":") || ((time.Split(":").Length - 1) > 1)) {
                Console.WriteLine("Incorrect input, Time Format is incorrect");
                return 1;
            }
            hoursString = time.Split(':')[0];
            minutesString = time.Split(':')[1];
            if (minutesString == "" || hoursString == "") {
                Console.WriteLine("Incorrect input, Minutes or hours field was empty");
                return 1;
            }
            if (!minutesString.All(char.IsDigit) || !hoursString.All(char.IsDigit)) {
                Console.WriteLine("Incorrect input, one or both of the inputs weren't digits");
                return 1;
            }
            minutes = Convert.ToInt32(minutesString);
            hours = Convert.ToInt32(hoursString);
            if (minutes < 0 || hours < 1 || minutes >= 60 || hours > 12) {
                Console.WriteLine("Incorrect input, the inputted time is not valid");
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
            Console.Write("This app calculates the lesser angle difference in degrees between two analogue clock hands\n" +
                    "Please only input the numbers, without 'Min' or 'h' and 'PM' or 'AM'\n" +
                    "Please use 12-hours clock format(e.g. instead of 13 hours, it's 1 hour)\n" +
                    "Hours go from 1 through 12\n" +
                    "Minutes go from 0 through 59\n\n");
            Console.Write("Input time(hh:mm): ");
            string? time = Console.ReadLine().Trim();

            if (ValidateAndSplitInput(time) != 0) {
                return 1;
            }
            minDegrees = minutes * DEGREES_IN_MINUTE;
            hDegrees = hours * DEGREES_IN_HOUR;
            int degDifference = CalculateDifference(minDegrees, hDegrees);
            Console.WriteLine($"Difference: {degDifference} Degrees");
            return 0;
        }
    }
}
