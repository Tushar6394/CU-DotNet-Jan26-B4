//Example of Method and also this is a Week3 assessment on Top Brains 
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