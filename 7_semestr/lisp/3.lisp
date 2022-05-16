; return list L trimmed before n elem
; i - current elem index
; n - index of elem to trim
(defun trim_list(L i n) (if (< n (length L)) (if (<= (+ i 1) n) (trim_list (cdr L) (+ i 1) (- n 1)) (cdr L))))

;sum of two lists
;max_l - list with max length (if L1, max_l = 1)
(defun sum(L1 L2)
  (let ((m (min (length L1) (length L2))) (itog_list nil) (max_l 2))
    (if (> (length L1) (length L2)) (setf max_l 1))
    (dotimes (i m)
             (setf itog_list (append itog_list (list (+ (nth i L1) (nth i L2))))))
    (if (AND (= max_l 1))
      (append itog_list (trim_list L1 0 m))
      (append itog_list (trim_list L2 0 m)))))

;write reverse list L in back of list L
(defun add_rev(L) (append L (reverse L)))

;find negative element and if it is, replase it with multiplication of it's neighbords
(defun negative_elem(L) (let ((itog_list (list (car L))))
                          (dotimes (i (- (length L) 2))
                                   (if (>= (nth (+ i 1) L) 0)
                                     (setf itog_list (append itog_list (list (nth (+ i 1) L))))
                                     (setf itog_list (append itog_list (list (* (nth i L) (nth (+ i 2) L)))))))
                          (append itog_list (list (nth (- (length L) 1) L)))))

;replase elements in list L with indexes i1 and i2
(defun repl(i1 i2 L) (if (AND (>= i1 0)
                              (>= i2 0)
                              (< i1 (- (length L) 1))
                              (< i2 (- (length L) 1))
                              (/= i1 i2))
                         (let ((buffer 0))
                           (setf buffer (nth i1 L))
                           (setf (nth i1 L) (nth i2 L))
                           (setf (nth i2 L) buffer)
                           (cond (T L)))))

;find all sublists in list L
(defun find_sublists(L) (let ((itog_list nil))
                          (dolist (elem L)
                                  (if (listp elem)
                                    (setf itog_list (append itog_list (list elem)))))
                          (cond (T itog_list))))
