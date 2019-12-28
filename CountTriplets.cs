static long countTriplets(List<long> arr, long r) {
        List<List<long>> result = new List<List<long>>();
        for(int i=0;i<=arr.Count-2;i++){
            List<long> triplet = new List<long>();
            triplet.Add(arr[i]);
            Backtracking(result, triplet, i, arr, r);
        }
        return result.Count;
    }

    static void Backtracking(List<List<long>> result, List<long> triplet, int ci, List<long> arr, long r){
        if(triplet.Count == 3){
            // Console.WriteLine("Triplet Found");
            result.Add(new List<long>(triplet.ToArray()));
            return;
        }
        var options = GetNextOptions(ci, arr, r);
        // Console.WriteLine(options.Count.ToString() + " options found");
        foreach(var option in options){
            triplet.Add(arr[option]);
            Backtracking(result,triplet, option, arr, r);
            triplet.RemoveAt(triplet.Count-1);
        }
    }

    static List<int> GetNextOptions(int ci, List<long> arr, long r){
        List<int> result = new List<int>();
        long currentItem = arr[ci];
        for(int i = ci+1;i<arr.Count;i++){
            if(arr[i] == r*currentItem){
                result.Add(i);
            }
        }
        return result;
    }
