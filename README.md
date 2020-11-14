# RandomBooleanNetwork

This project was inspired by the Computerphile video: Random Boolean Networks.

## Building the app

The app is written in C# .Net Core 3.1.  The Project can be built with:
```
dotnet build
```

## Running the app

```
Usage:
  RandomBooleanNetwork [options]

Options:
  --generations <generations>    generations [default: 100]
  --links <links>                links [default: 4]
  --nodes <nodes>                nodes [default: 20]
  --state-file <state-file>      stateFile [default: ]
  --version                      Show version information
  -?, -h, --help                 Show help and usage information
```

When the the app runs without a state-file, a random network is generated using the number of `--nodes` and `--links`.  The state of the network is stored in a state-file to allow re-running the network.

If `--state-file` option is provided then that file is loaded and used as the initial configuration of the network.  The nodes and links options will be ignored in this case.

The `--generations` option can be provided for both new and re-run networks.

## Computerphile Video
[![Computerphile video](imgs/Computerphile.png)](https://www.youtube.com/watch?v=mCML2B94rUg)

## Example Output
```
0            #   # # #     #             # #      
1            # #       #   # # #   #   #   #     #
2              # #   # #       #   #         #   #
3              # # # #   #           # #     # # #
4            # # # #   #       #     #     #      
5              #   # # #   #       #   # # # # # #
6          # #         # #     #     #           #
7              # #   # #   #   #     #   # # # # #
8                # #                   #
9            #         #               #
10                   # #   #                   #  
11                   #       # #   # #         #  
12         #     # # #   #   #           # # # # #
13           #   #     #   #   #   #       # # # #
14         #       # # #   # #         #     # #  
15           #       # # # #   # # # #
16               # #   # # # #   # #   #   # # # #
17         #         #       #   #       #   #    
18         #             # #     #         #   #  
19         #   #           #   # #   # # #        
20                 #       #   # # #     #       #
21           # #   # # # #     #   # #     # #   #
22               # #   # # #   # # # # #   #   # #
23                 #   #                 #   # #  
24           #       # #     #       #     #   #
25             #     # # # # #     # #   # # # # #
26         #                     #     #         #
27         #   # #         #     #   #       #
28         # #     #       #   #       # # # #
29           # #       #   # # # #               #
30             # # # #   #     #   #         #   #
31             # # # # # #     # #   #       #   #
32               # # # #             #     #   # #
33             # #   # #     #     # # # # # # # #
34         # #                     #   #         #
35         #   # # # # # # #     #   #       #
36         #       # # #   #               # #
37           # #     # #   #   # #             # #
38             #   # # #   # # #   #         #
39               #   # # #     #   #             #
40         #   # # # #   #   #   #   #   #   # # #
41         # #     #     #     #           #   #  
42           # #       #   #   # # # # # #
43               #     # # #   #   #     #       #
44         #   # # #     #       # # #   # # # # #
45           #     #   #   #   #     #     #
46             #     # #   #   #   #     # # # # #
47                 #     #     #           #
48           # #       #       # # #   # #       #
49             #       # # #         #     #   # #
50             # # # #           # # # # # #     #
51           #         #     #     # # # #       #
52         #   # #     # # #         #   #     #
53           #     #       #       # #   #        
54         # #   # #   # # #   #   #     #   #    
55         #     # #   # # # #     #     # #   # #
56         #   #   #   #   #       #     # # #   #
57         # #   # #   # # #   # #   #     #     #
58         #     #   #     #         #   # # # #
59           # #           #   #     # #     #   #
60             # # #   #   # # #   # #   #       #
61             # #     #           #   # #       #
62         # # # #       #           # #   #   #
63           # #   #   #       #   # #   # # #   #
64               # #   # # # #     # #   # #   # #
65         #   #   #   #           #     #       #
66         # # # # #   # # #     #   #     #   #  
67         #   #   # #               #   # # #
68           # #   #   #   #     # #       #     #
69           #     # #   # #   #     #       #   #
70           # # #     #   # # # # # # #   # #   #
71                           #         # #
72                       #                 #   #
73             #               # # # # # #       #
74             #         #           #   #       #
75             # # #           # #   # # # #
77         # #   #     # #                 #   #
78           # #     # #   #       # #   #     # #
79         #   #   #   # # # # #   # #   #
80               #     # #         #   # #       #
81         # # # # #     #       #   #   # # # #
82         # #     #           #     #     #
83           # #       #   #     # #     # # #   #
84                 #   # # # # #     #     #     #
85             # #   # # #       # #   # # # #   #
86           #                   #   #     #   # #
87         #           #   #       # #   # # #
88         #   # # #     # # # # #       #   # # #
89                 #     #               # #
90           # #       #       # # #   # # #     #
91                     # # #       # #     #   #
92         #   # # #     #       # # # # # # # # #
93           #         #   #   #     #
94                   # #   #   #   #     # # # # #
95         #       #     #   # #           # # #
96           # #       # # # # # # #   # #     #
97                       #       # #   # #
98         #     # # #   #     # #     # # #
99         #   #       #   # # #   #     # #
State Id: d8a399a0-ec66-4326-812e-ee14659ac862
```