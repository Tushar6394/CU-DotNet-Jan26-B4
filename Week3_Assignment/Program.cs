//Example of Method and also this is a Week3 assessment on Top Brains 
// Question: Write a method to calculate the membership amount for a month for joining a Gym depending on various services you are opting for - At least one service is mandatory, otherwise add 200. 
// Fixed Charges Monthly - Rs. 1000 
// Tread-Mill - 300 
// Weight Lifting - 500 
// Zumba Classes - 250 
// GST - 5% 
public class Solution{
public static double CalculateGymBill(bool tread, bool weight, bool zumba)
{
    double amt=1000;
    if(!tread && !weight && !zumba)
    {
        amt+=200;
    }
    else{
        amt+=tread?300:0;
        amt+=weight?500:0;
        amt+=zumba?250:0;
    }

    return (amt+amt*0.05);
}

}