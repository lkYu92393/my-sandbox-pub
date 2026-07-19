import numpy as np
import pandas as pd
import datetime
import random
import math

def get_progress():

    # progress = get_total_count_of_graded_from_db()
    progress = math.floor(random.random() * 100)
    # total = get_total_count_from_db()
    total = progress + math.floor(random.random() * 200 +50)
    
    result = "{}/{}".format(progress, total)

    # update record for future use

    return {
        "progress": result
    }

def get_random_record():
    # doc = get_all_records_from_db()
    # records = []
    # for rec in doc:
    #     records.append(rec)
    # record = records[math.floor(random.random() * len(records))]

    from_time_str = "2023-03-01 00:00:00"
    to_time_str = "2023-03-01 01:00:00"
    record = "001"
    x = np.linspace(0, (3.14 + 3.14 * random.random()), 60)
    y = np.sin(x)
    dataset = pd.DataFrame(zip(x,y),columns=["x","y"])
    data_json = dataset.to_json()

    return {
        "recordID": record
        ,"fromTime": from_time_str
        ,"toTime": to_time_str
        ,"data": data_json
    }

def add_grading_and_remove_record(data):
    # do something
    pass