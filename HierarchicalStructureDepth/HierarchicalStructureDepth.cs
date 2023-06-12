namespace HierarchicalStructureDepth {
    
    public class Branch {
        public List<Branch> branches = new List<Branch>();
    }

    //Calculate randomly generated Hierarchical strucutre depth
    public class HierarchicalStructureDepth {
        const int DEPTH = 10;        //Node tree depth
        const int MAX_CHILDREN = 3; //Max chidlren per node
        int depth = 0,currentLevel = 0;      
        public void Start() {
            Branch branch = GenerateStructure();
            depth = 0;
            FindStructureDepth(branch);
            Console.WriteLine("Depth of the given structure is: " + depth.ToString());
            Console.WriteLine("\n\nPress any key to exit");
            Console.ReadKey();
        }
        public void FindStructureDepth(Branch recursiveBranch) {
            currentLevel++;
            if (currentLevel > depth) {
                depth = currentLevel;
            }
            foreach (Branch branch in recursiveBranch.branches) {
                FindStructureDepth(branch);
            }
            currentLevel--;
            return;
        }
        public Branch GenerateStructure() {
            Branch branch = new Branch();
            if (depth < DEPTH - 1) {
                depth++;
                Random random = new Random();
                int children = random.Next(1, MAX_CHILDREN);
                for (int i = 0; i < children; i++) {
                    branch.branches.Add(GenerateStructure());
                }
                depth--;
            }
            return branch;
        }
    }
}
