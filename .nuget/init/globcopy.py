#!/usr/bin/env python3
# globcopy.py

"""
...
"""

import sys

from jpyz import common, default
from jpyz.constant import Constant
from jpyz.default import Default


def main(arg):
    """
    ...
    :param arg:
    :type arg: list
    :return:
    """


# determine call method...
if common.isScript():
    # run script...
    main(sys.argv)
