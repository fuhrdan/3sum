//*****************************************************************************
//** 15. 3Sum leetcode                                                       **
//** Dynamically allocated memory for adjustment to find the answer -Dan     **
//*****************************************************************************

/**
 * Return an array of arrays of size *returnSize.
 * The sizes of the arrays are returned as *returnColumnSizes array.
 * Note: Both returned array and *columnSizes array must be malloced, assume caller calls free().
 */
int compare(const void *a, const void *b) {
    return (*(int *)a - *(int *)b);
}

int** threeSum(int* nums, int numsSize, int* returnSize, int** returnColumnSizes) {
    // Initial allocation size
    int capacity = 100000;

    // Allocate memory for the result arrays
    int** result = (int **)malloc(capacity * sizeof(int *));
    *returnColumnSizes = (int *)malloc(capacity * sizeof(int));
    *returnSize = 0;
    
    // Sort the array
    qsort(nums, numsSize, sizeof(int), compare);
    
    // Loop through the array
    for (int i = 0; i < numsSize - 2; i++) {
        if (i > 0 && nums[i] == nums[i - 1]) continue; // Skip duplicates
        int left = i + 1;
        int right = numsSize - 1;
        while (left < right) {
            int sum = nums[i] + nums[left] + nums[right];
            if (sum == 0) {
                // Allocate memory for the new triplet
                result[*returnSize] = (int *)malloc(3 * sizeof(int));
                result[*returnSize][0] = nums[i];
                result[*returnSize][1] = nums[left];
                result[*returnSize][2] = nums[right];
                (*returnColumnSizes)[*returnSize] = 3;
                (*returnSize)++;
                
                // Move left and right pointers and skip duplicates
                while (left < right && nums[left] == nums[left + 1]) left++;
                while (left < right && nums[right] == nums[right - 1]) right--;
                left++;
                right--;
            } else if (sum < 0) {
                left++;
            } else {
                right--;
            }
        }
    }
    
    return result;
}