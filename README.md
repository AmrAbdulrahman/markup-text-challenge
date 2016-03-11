# Markup Text Challenge

> This is an application that uses [Aho Corasick](https://en.wikipedia.org/wiki/Aho%E2%80%93Corasick_algorithm) algorithm
> to find list of keywords in a text, and <mark>s these matches giving priority to longer keywords

## Problem Statement
[Here's the full problem statement](https://app.box.com/s/fnsgkc2ouj9zeacnw04xgfn2n8zixxns)

## Idea
Aho Corasick extends [KMP Algorithm](https://en.wikipedia.org/wiki/Knuth%E2%80%93Morris%E2%80%93Pratt_algorithm) to find and match list of keywords in a text.

## Complexity
Let
- N: length of input string
- M: length of targets text
- K: length of matches

Complexity of:
- building the trie: O(M)
- building failure links using BFS: O(M)
- matching text: O(N + K)
- markup text: O(K log K + K + N)

Overall: 
**O(K log K + N + M + K)**

## Run
```
clone repo
cd /(repo-root)/MarkupTextChallenge/bin/Debug
MarkupTextChallenge.exe -input input-file-path.txt -target targets-file-path.txt
```

## Help
```
MarkupTextChallenge.exe -help
```

[Directly go to source files](https://github.com/AmrAbdulrahman/markup-text-challenge/tree/master/MarkupTextChallenge/Source)
