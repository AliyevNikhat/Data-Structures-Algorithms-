#include <bits/stdc++.h>
#include <chrono>     
#include <thread>      
using namespace std;

#define ll long long int
#define ull unsigned long long
#define ld long double
#define S second
#define F first
#define pb push_back
#define map unordered_map
#define unset unordered_set
#define all(a) a.begin(), a.end()
#define intmin INT32_MIN
#define optimize() ios_base::sync_with_stdio(0);cin.tie(0);cout.tie(0);
#define fraction() cout.unsetf(ios::floatfield); cout.precision(10); cout.setf(ios::fixed,ios::floatfield);
#define MX 100000
#define fs first
#define sc second
#define vi vector<int>
#define pi pair<int, int>
#define TC int T;cin>>T;while(T--)
#define loop(j,n,a) for(int j=n;j<a;j++)
#define loop1(j,n,a) for(int j=n;j<=a;j++)
#define sz(x) (sizeof(x)/sizeof(x[0]))
/*
    Shortest Path Finder in a Grid (from A to B)

    Description:
    This program uses BFS to find the shortest path from point 'A' to 'B' in a given 2D grid.

    Symbols:
    '#' = wall
    '.' = free path
    'A' = start
    'B' = end

    Input:
    First line: two integers n and m
    Next n lines: grid with n rows and m columns

    Example:
    5 8
    ########
    #.A#...#
    #.##.#B#
    #......#
    ########

    Output:
    - Shortest distance
    - Path directions (e.g., RRDLL)

    Author: Aliyev Nikhat
*/
int dx[] = {1, -1, 0, 0};
int dy[] = {0, 0, 1, -1};
char dir[] = {'D', 'U', 'R', 'L'};

void printGrid(const vector<vector<char>>& V, const vector<vector<bool>>& vis) {
    for (int i = 0; i < V.size(); i++) {
        if(i==0){
            cout<<endl;
        }
        for (int j = 0; j < V[0].size(); j++) {
            if (vis[i][j]) {
                cout << '*';
            } else {
                cout << V[i][j];
            }
        }
        cout << endl;
    }
    cout << "--------------------" << endl;
    this_thread::sleep_for(chrono::milliseconds(300)); 
}

void solve() {
    int n, m;
    cin >> n >> m;
    vector<vector<char>> V(n, vector<char>(m));
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
            cin >> V[i][j];
        }
    }
    int ai = -1, bj = -1;
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
            if (V[i][j] == 'A') {
                ai = i;
                bj = j;
            }
        }
    }
    if (ai == -1 || bj == -1) {
        cout << "NO";
        return;
    }

    queue<pair<int, int>> q;
    vector<vector<bool>> vis(n, vector<bool>(m, false));
    vector<vector<char>> parentDir(n, vector<char>(m));
    vector<vector<pair<int, int>>> parent(n, vector<pair<int, int>>(m));
    q.push({ai, bj});
    vis[ai][bj] = true;

    bool found = false;
    while (!q.empty()) {
        auto [i, j] = q.front();
        q.pop();
        
            printGrid(V, vis);
        
        if (V[i][j] == 'B') {
            found = true;
            break;
        }
        for (int x = 0; x < 4; x++) {
            int ni = i + dx[x];
            int nj = j + dy[x];
            if (ni >= 0 && nj >= 0 && ni < n && nj < m && !vis[ni][nj] && (V[ni][nj] == '.' || V[ni][nj] == 'B')) {
                q.push({ni, nj});
                vis[ni][nj] = true;
                parentDir[ni][nj] = dir[x];
                parent[ni][nj] = {i, j};
            }
        }
    }

    if (!found) {
        cout << "NO";
        return;
    }

    vector<char> path;
    int ci = -1, cj = -1;
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
            if (V[i][j] == 'B') {
                ci = i;
                cj = j;
                break;
            }
        }
    }
    while (ci != ai || cj != bj) {
        path.push_back(parentDir[ci][cj]);
        auto [i, j] = parent[ci][cj];
        ci = i;
        cj = j;
    }
    reverse(path.begin(), path.end());
    cout << "YES" << endl << path.size() << endl;
    for (char c : path) {
        cout << c;
    }
    cout<<endl;
}

int main() {
    optimize()
    int t=1;
    while(t--){
        solve();
    }
    system("pause");
    return 0;
}