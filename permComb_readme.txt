Πόσοι είναι οι αναγραμματισμοί μιας λέξης με 6 γράμματα τα οποία είναι όλα διαφορετικά μεταξύ τους;
διάταξη 6 ανά 6, μετάθεση 6			6!

Πόσα χέρια υπαρχουν στο ποκερ με 5 κοινά χαρτιά και 2 στο χέρι
συνδυασμός 7 ανά 5		21

Πόσοι αριθμοί μπορούν να γραφτούν με 6 βάση10 ψηφία;
επαναλληπτική διάταξη 10 ανά 6		10^6

Πόσοι απο τους παραπανω αριθμους εχουν τα ψηφία τους σε αύξουσα σειρά (επιτρέπονται διαδοχικά ίδια ψηφία);
επαναλληπτικός συνδυασμός 10 ανά 6	5005


how many different words exist if we change the order of the letters of a word with 6 letters that are all different with each other?
permutation n=6 k=6					6^6

how many poker hands with 5 community cards?
combination n=7 k=5					21

how many numbers can be written with 6 10-based digits?
repetitive permutation n=10 k=6		10^6

how many of those numbers have their digits in ascending order (consecutive equal digits allowed)?
repetitive combination n=10 k=6		5005





Σε αυτό το πρόγραμμα υπάρχουν 4 κλάσεις singleton (με πρόθεμα EF) οι οποιες δημιουργούν απαριθμητές οι οποίοι απαριθμούν όλους τους συνδυασμούς ή διατάξεις για δεδομένα ν και κ
Το πλήθος ή ένα συγκεκριμένο στοιχείο της απαρίθμησης ένας τρόπος υπολογισμού είναι καλώντας επανηλλημένα τον απαριθμητή όλες ή μερικές φορές αντίστοιχα.
Για το πλήθος και οι 4 κλάσεις έχουν συγκεκριμένο μαθηματικό τύπο που το υπολογίζει

Ενας δασκαλος μου έδειξε αυτό το άρθρο (απο το MSDN Magazine):
link here
και με αυτό (απο το Wikipedia):
link here
εγραψα 2 αλγόριθμους για την εύρεση κάποιου στοιχείου μιας διάταξης ή ενός συνδυασμού χρησιμοποιώντας το factoradic και combinadic αντίστοιχα.
Για τα αντίστοιχα επαναλληπτικά δεν ξέρω αν υπάρχει παρόμοιος τρόπος. Ειδικά τα επαναλληπτικά είναι που έχουν πολλά στοιχεία.
Επίσης για τις διατάξεις βρήκα τρόπο μόνο για ν=κ (μετάθεση).



The element that the enumerators return in every step of the iteration is an array of integers with length k. These integers are in the set [0, n-1] or [1, n] depending on the IndexBase property.
They can be used as indexes in any other array to select all possible  combinations or permutations.