namespace HierarchicalStructureDepth {
    public class Branch {
        public List<Branch> branches = new List<Branch>();
    }
    public class HierarchicalStructureDepth {
        const int DEPTH = 7;       //Node tree depth
        const int MAX_CHILDREN = 3; //Max chidlren per node
        int depth = 0,level = 0;      
        public void Start() {
            Branch branch = GenerateBranch();
            depth = 0;
            FindDepth(branch);
            Console.WriteLine(depth);
        }
        public void FindDepth(Branch recursiveBranch) {
            level++;
            if (level > depth) {
                depth = level;
            }
            foreach (Branch branch in recursiveBranch.branches) {
                FindDepth(branch);
            }
            level--;
            return;
        }
        public Branch GenerateBranch() {
            Branch branch = new Branch();
            if (depth < DEPTH - 1) {
                depth++;
                Random random = new Random();
                int children = random.Next(1, MAX_CHILDREN);
                
                for (int i = 0; i < children; i++) {
                    branch.branches.Add(GenerateBranch());
                }
                depth--;
            }
            return branch;
        }
    }
}
