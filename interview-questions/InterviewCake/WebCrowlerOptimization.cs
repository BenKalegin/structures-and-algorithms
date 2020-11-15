namespace interview_questions.InterviewCake
{
    class WebCrowlerOptimization
    {
        // I wrote a crawler that visits web pages, stores a few keywords in a database, and follows links to other web pages.
        // I noticed that my crawler was wasting a lot of time visiting the same pages over and over, so I made a set, visited,
        // where I'm storing URLs I've already visited. Now the crawler only visits a URL if it hasn't already been visited.
        // Thing is, the crawler is running on my old desktop computer in my parents' basement (where I totally don't live anymore),
        // and it keeps running out of memory because visited is getting so huge.
        // How can I trim down the amount of space taken up by visited?

        // Use distributed hash in cloud (with consistent hashing)

        // assuming we have 10mbyte traffic at home
        // average page say 100Kbytes so peak performance is 100 sites per second, 100M per day

        // 2% False Pos bloom filter takes 8 bits per entry, 10% 5 bit.  1Gb per day

        // Trie indexing by letter 
    }
}
